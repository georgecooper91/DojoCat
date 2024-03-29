﻿// <auto-generated />
using System;
using DojoCat.Members.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DojoCat.Members.Infrastructure.Migrations
{
    [DbContext(typeof(MembersDbContext))]
    partial class MembersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.ContactDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("EmergencyContactId")
                        .HasColumnType("bigint");

                    b.Property<long?>("InternationalCallingCode")
                        .HasColumnType("bigint");

                    b.Property<long?>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("PreferedMethodOfContact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyContactId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.EmergencyContact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("ActiveMember")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("DeleteMember")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("Joined")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserReference")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.Address", b =>
                {
                    b.HasOne("DojoCat.Members.Infrastructure.Models.Member", "Member")
                        .WithOne("Address")
                        .HasForeignKey("DojoCat.Members.Infrastructure.Models.Address", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.ContactDetails", b =>
                {
                    b.HasOne("DojoCat.Members.Infrastructure.Models.EmergencyContact", "EmergencyContact")
                        .WithMany("ContactDetails")
                        .HasForeignKey("EmergencyContactId");

                    b.HasOne("DojoCat.Members.Infrastructure.Models.Member", "Member")
                        .WithOne("ContactDetails")
                        .HasForeignKey("DojoCat.Members.Infrastructure.Models.ContactDetails", "MemberId");

                    b.Navigation("EmergencyContact");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.EmergencyContact", b =>
                {
                    b.HasOne("DojoCat.Members.Infrastructure.Models.Member", "Member")
                        .WithMany("EmergencyContact")
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.EmergencyContact", b =>
                {
                    b.Navigation("ContactDetails");
                });

            modelBuilder.Entity("DojoCat.Members.Infrastructure.Models.Member", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ContactDetails")
                        .IsRequired();

                    b.Navigation("EmergencyContact");
                });
#pragma warning restore 612, 618
        }
    }
}
