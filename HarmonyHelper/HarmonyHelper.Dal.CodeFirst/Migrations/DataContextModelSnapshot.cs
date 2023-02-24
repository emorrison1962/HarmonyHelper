﻿// <auto-generated />
using HarmonyHelper.Dal.CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HarmonyHelper.Dal.CodeFirst.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Eric.Morrison.Harmony.Intervals.Interval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IntervalRoleType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SemiTones")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Intervals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IntervalRoleType = 1,
                            Name = "Diminished2nd",
                            SemiTones = 0,
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            IntervalRoleType = 0,
                            Name = "Augmented Unison",
                            SemiTones = 1,
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            IntervalRoleType = 1,
                            Name = "Minor2nd",
                            SemiTones = 1,
                            Value = 2
                        },
                        new
                        {
                            Id = 4,
                            IntervalRoleType = 1,
                            Name = "Major2nd",
                            SemiTones = 2,
                            Value = 4
                        },
                        new
                        {
                            Id = 5,
                            IntervalRoleType = 2,
                            Name = "Diminished3rd",
                            SemiTones = 2,
                            Value = 4
                        },
                        new
                        {
                            Id = 6,
                            IntervalRoleType = 1,
                            Name = "Augmented2nd",
                            SemiTones = 3,
                            Value = 8
                        },
                        new
                        {
                            Id = 7,
                            IntervalRoleType = 2,
                            Name = "Minor3rd",
                            SemiTones = 3,
                            Value = 8
                        },
                        new
                        {
                            Id = 8,
                            IntervalRoleType = 2,
                            Name = "Major3rd",
                            SemiTones = 4,
                            Value = 16
                        },
                        new
                        {
                            Id = 9,
                            IntervalRoleType = 3,
                            Name = "Diminished4th",
                            SemiTones = 4,
                            Value = 16
                        },
                        new
                        {
                            Id = 10,
                            IntervalRoleType = 3,
                            Name = "Perfect4th",
                            SemiTones = 5,
                            Value = 32
                        },
                        new
                        {
                            Id = 11,
                            IntervalRoleType = 2,
                            Name = "Augmented3rd",
                            SemiTones = 5,
                            Value = 32
                        },
                        new
                        {
                            Id = 12,
                            IntervalRoleType = 3,
                            Name = "Augmented4th",
                            SemiTones = 6,
                            Value = 64
                        },
                        new
                        {
                            Id = 13,
                            IntervalRoleType = 4,
                            Name = "Diminished5th",
                            SemiTones = 6,
                            Value = 64
                        },
                        new
                        {
                            Id = 14,
                            IntervalRoleType = 4,
                            Name = "Perfect5th",
                            SemiTones = 7,
                            Value = 128
                        },
                        new
                        {
                            Id = 15,
                            IntervalRoleType = 5,
                            Name = "Diminished6th",
                            SemiTones = 7,
                            Value = 128
                        },
                        new
                        {
                            Id = 16,
                            IntervalRoleType = 4,
                            Name = "Augmented5th",
                            SemiTones = 8,
                            Value = 256
                        },
                        new
                        {
                            Id = 17,
                            IntervalRoleType = 5,
                            Name = "Minor6th",
                            SemiTones = 8,
                            Value = 256
                        },
                        new
                        {
                            Id = 18,
                            IntervalRoleType = 5,
                            Name = "Major6th",
                            SemiTones = 9,
                            Value = 512
                        },
                        new
                        {
                            Id = 19,
                            IntervalRoleType = 5,
                            Name = "Augmented6th",
                            SemiTones = 10,
                            Value = 1024
                        },
                        new
                        {
                            Id = 20,
                            IntervalRoleType = 6,
                            Name = "Diminished7th",
                            SemiTones = 9,
                            Value = 512
                        },
                        new
                        {
                            Id = 21,
                            IntervalRoleType = 6,
                            Name = "Minor7th",
                            SemiTones = 10,
                            Value = 1024
                        },
                        new
                        {
                            Id = 22,
                            IntervalRoleType = 6,
                            Name = "Major7th",
                            SemiTones = 11,
                            Value = 2048
                        },
                        new
                        {
                            Id = 23,
                            IntervalRoleType = 7,
                            Name = "Diminished Octave",
                            SemiTones = 11,
                            Value = 2048
                        },
                        new
                        {
                            Id = 24,
                            IntervalRoleType = 7,
                            Name = "Perfect Octave",
                            SemiTones = 12,
                            Value = 1
                        },
                        new
                        {
                            Id = 25,
                            IntervalRoleType = 6,
                            Name = "Augmented7th",
                            SemiTones = 12,
                            Value = 1
                        });
                });

            modelBuilder.Entity("Eric.Morrison.Harmony.NoteName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AsciiSortValue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFlatted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNatural")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSharped")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("NoteNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AsciiSortValue = 0,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "C",
                            Value = 2
                        },
                        new
                        {
                            Id = 2,
                            AsciiSortValue = 0,
                            IsFlatted = false,
                            IsNatural = false,
                            IsSharped = true,
                            Name = "C♯",
                            Value = 4
                        },
                        new
                        {
                            Id = 3,
                            AsciiSortValue = 1,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "D♭",
                            Value = 4
                        },
                        new
                        {
                            Id = 4,
                            AsciiSortValue = 1,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "D",
                            Value = 8
                        },
                        new
                        {
                            Id = 5,
                            AsciiSortValue = 1,
                            IsFlatted = false,
                            IsNatural = false,
                            IsSharped = true,
                            Name = "D♯",
                            Value = 16
                        },
                        new
                        {
                            Id = 6,
                            AsciiSortValue = 2,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "E♭",
                            Value = 16
                        },
                        new
                        {
                            Id = 7,
                            AsciiSortValue = 2,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "E",
                            Value = 32
                        },
                        new
                        {
                            Id = 8,
                            AsciiSortValue = 3,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "F♭",
                            Value = 32
                        },
                        new
                        {
                            Id = 9,
                            AsciiSortValue = 2,
                            IsFlatted = false,
                            IsNatural = false,
                            IsSharped = true,
                            Name = "E♯",
                            Value = 64
                        },
                        new
                        {
                            Id = 10,
                            AsciiSortValue = 3,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "F",
                            Value = 64
                        },
                        new
                        {
                            Id = 11,
                            AsciiSortValue = 3,
                            IsFlatted = false,
                            IsNatural = false,
                            IsSharped = true,
                            Name = "F♯",
                            Value = 128
                        },
                        new
                        {
                            Id = 12,
                            AsciiSortValue = 4,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "G♭",
                            Value = 128
                        },
                        new
                        {
                            Id = 13,
                            AsciiSortValue = 4,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "G",
                            Value = 256
                        },
                        new
                        {
                            Id = 14,
                            AsciiSortValue = 4,
                            IsFlatted = false,
                            IsNatural = false,
                            IsSharped = true,
                            Name = "G♯",
                            Value = 512
                        },
                        new
                        {
                            Id = 15,
                            AsciiSortValue = 5,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "A♭",
                            Value = 512
                        },
                        new
                        {
                            Id = 16,
                            AsciiSortValue = 5,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "A",
                            Value = 1024
                        },
                        new
                        {
                            Id = 17,
                            AsciiSortValue = 5,
                            IsFlatted = false,
                            IsNatural = false,
                            IsSharped = true,
                            Name = "A♯",
                            Value = 2048
                        },
                        new
                        {
                            Id = 18,
                            AsciiSortValue = 6,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "B♭",
                            Value = 2048
                        },
                        new
                        {
                            Id = 19,
                            AsciiSortValue = 6,
                            IsFlatted = false,
                            IsNatural = true,
                            IsSharped = false,
                            Name = "B",
                            Value = 4096
                        },
                        new
                        {
                            Id = 20,
                            AsciiSortValue = 0,
                            IsFlatted = true,
                            IsNatural = false,
                            IsSharped = false,
                            Name = "C♭",
                            Value = 4096
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
