using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public static partial class ReflectionExtensions
    {
        public static void Copy(this object dst, object src)
        {
            if (null == src)
                return;
            dst.CopyFields(src);
            dst.CopyProperties(src);
        }
        public static void CopyFields(this object dst, object src)
        {
            var fis = dst.GetType().GetFields().ToList();
            foreach (var fi in fis)
            {
                if (!fi.IsStatic)
                {
                    var srcVal = (dynamic)fi.GetValue(src) as IComparable;
                    fi.SetValue(dst, srcVal);
                }
            }
        }
        public static void CopyProperties(this object dst, object src)
        {
            if (null == src)
                return;

            var srcPis = src.GetType().GetProperties().ToList();
            var dstPis = dst.GetType().GetProperties().ToList();

            var pairs = (from srcPi in srcPis
                         from dstPi in dstPis
                         where srcPi.Name == dstPi.Name
                            && srcPi.PropertyType == dstPi.PropertyType
                         select new { SrcPi = srcPi, DstPi = dstPi }).ToList();

            foreach (var pair in pairs)
            {
                if (!pair.SrcPi.GetMethod.IsStatic)
                {
                    var srcVal = pair.SrcPi.GetValue(src);
                    if (null != pair.DstPi.SetMethod)
                    {
                        pair.DstPi.SetValue(dst, srcVal);
                    }
                    else
                    {
                        new object();
                    }
                }
            }
        }

        public static List<PropertyValue> GetPropertyValueStrings(this object src)
        {
            var result = new List<PropertyValue>();
            var pis = src.GetType().GetProperties().ToList();

            foreach (var pi in pis)
            {
                var srcVal = pi.GetValue(src);
                result.Add(new PropertyValue(pi.Name, srcVal));
            }
            return result;
        }

        public class PropertyValue
        {
            public string Name { get; protected set; }
            public object Value { get; protected set; }

            public PropertyValue(string name, object value)
            {
                this.Name = name;
                this.Value = value;
            }
            public override string ToString()
            {
                var valStr = "null";
                if (null != this.Value)
                {
                    valStr = this.Value.ToString();
                }
                return $"{this.Name}= {valStr}";
            }
        }

        class IndentedTextWriterContext : IDisposable
        {
            private bool disposedValue;

            IndentedTextWriter Writer { get; set; }
            public IndentedTextWriterContext(Type src, IndentedTextWriter writer)
            {
                this.Writer = writer;
                this.Writer.WriteLine($"{src.Name}");
                this.Writer.WriteLine($"{{");

                writer.Indent++;
            }

            public IndentedTextWriterContext(string name, IndentedTextWriter writer)
            {
                this.Writer = writer;
                this.Writer.WriteLine($"{name}");
                this.Writer.WriteLine($"{{");

                writer.Indent++;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        this.Writer.Indent--;
                        this.Writer.WriteLine($"}}");
                    }
                    disposedValue = true;
                }
            }
            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }


        public static string ToStringEx(this string src,
            IndentedTextWriter itw = null)
        {
            return null;
        }

        const string SYSTEM_COLLECTIONS_GENERIC = "System.Collections.Generic";
        const string SYSTEM = "System";

        public static string ToStringEx<T>(this T src,
            IndentedTextWriter itw = null) where T : class
        {
            string result = null;
            if (itw == null)
            {
                var baseTextWriter = new StringWriter();
                itw = new IndentedTextWriter(baseTextWriter);
            }


            using (var ctx = new IndentedTextWriterContext(src.GetType(), itw))
            {
                var type = src.GetType();
                var pis = type.GetProperties();

                foreach (var pi in pis)
                {
                    var propName = pi.Name;
                    var propType = pi.PropertyType;
                    var propVal = pi.GetValue(src);

                    if (null == propVal)
                    {
                        itw.WriteLine($"{propName}={{null}}");
                    }
                    else if (propType.IsPrimitive
                        || propType.IsValueType
                        || propVal is string)
                    {
                        itw.WriteLine($"{propName}={propVal}");
                    }

                    else if (propType.IsArray)
                    {
                        using (new IndentedTextWriterContext(propName, itw))
                        {
                            var count = GetArrayCount(propVal);
                            itw.WriteLine($"{propName}.Count= {count}");
                        }
                    }
                    else if (propVal is List<string>)
                    {
                        (propVal as List<string>)
                            .ToStringEx(itw, propName);
                    }
                    else if (propType.Namespace == SYSTEM_COLLECTIONS_GENERIC)
                    {
                        (propVal as IList)
                            .ToStringEx(itw, propName);
                    }
                    else if (propType.IsClass)
                    {
                        propVal.ToStringEx(itw);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }


            if (itw.Indent == 0)
            {
                result = itw.InnerWriter.ToString();
            }
            return result;
        }

        private static void ToStringEx(this List<string> propVal, IndentedTextWriter itw, string propName)
        {
            using (new IndentedTextWriterContext(propName, itw))
            {
                foreach (var str in propVal)
                {
                    itw.WriteLine($"{str}");
                }
            }
        }

        private static void ToStringEx(this IList propVal, IndentedTextWriter itw, string propName)
        {
            using (new IndentedTextWriterContext(propName, itw))
            {
                if (propVal is List<Double[]>)
                {
                    var count = GetArrayCount(propVal);
                    itw.WriteLine($"{propName}.Count= {count}");
                }

                else
                {
                    if (propVal?.Count > 0)
                    {
                        foreach (var child in (propVal as IList))
                        {
                            child.ToStringEx(itw);
                        }
                    }
                }
            }
        }

        static public int GetArrayCount(object src)
        {
            var result = 0;
            result = (src as ICollection).Count;
            return result;
        }

    }//class
}//ns
