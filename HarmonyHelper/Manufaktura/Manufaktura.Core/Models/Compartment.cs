﻿/*
Copyright 2018 Manufaktura Programów Jacek Salamon
Website: http://musicengravingcontrols.com/
Patreon: https://www.patreon.com/jacek_salamon

MIT LICENCE

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace Manufaktura.Core.Models
{
    public class Compartment
    {
        public double? From { get; set; }
        public double? To { get; set; }

        public override string ToString()
        {
            if (From.HasValue && To.HasValue) return $"{From:0.00} - {To:0.00}";
            else if (From.HasValue) return $"{From:0.00} - inf.";
            else if (To.HasValue) return $"-inf. - {To:0.00}";
            else return base.ToString();
        }

        public Compartment CorrectOrder()
        {
            if (!From.HasValue || !To.HasValue) return this;
            if (From < To) return this;
            var from = From;
            From = To;
            To = from;
            return this;
        }
    }
}