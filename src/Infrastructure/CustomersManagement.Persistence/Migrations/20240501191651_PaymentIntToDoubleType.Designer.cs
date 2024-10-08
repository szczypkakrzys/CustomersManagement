﻿// <auto-generated />
using System;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomersManagement.Persistence.Migrations
{
    [DbContext(typeof(CustomerDatabaseContext))]
    [Migration("20240501191651_PaymentIntToDoubleType")]
    partial class PaymentIntToDoubleType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomersManagement.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Voivodeship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.CustomersDivingCoursesRelations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("AdvancedPaymentDate")
                        .HasColumnType("date");

                    b.Property<double>("AdvancedPaymentLeftToPay")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DivingCourseId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EnrollmentDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EntireAmountPaymentDate")
                        .HasColumnType("date");

                    b.Property<double>("EntireCostLeftToPay")
                        .HasColumnType("float");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DivingCourseId");

                    b.ToTable("CustomersDivingCoursesRelations");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.DivingCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AdvancePaymentCost")
                        .HasColumnType("float");

                    b.Property<DateOnly>("AdvancePaymentDeadline")
                        .HasColumnType("date");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EntireAmountPaymentDeadline")
                        .HasColumnType("date");

                    b.Property<double>("EntireCost")
                        .HasColumnType("float");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("TimeEnd")
                        .HasColumnType("date");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("TimeStart")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("DivingCourses");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.DivingSchoolCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("DivingCertificationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("DivingSchoolCustomers");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.CustomersToursRelations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("AdvancedPaymentDate")
                        .HasColumnType("date");

                    b.Property<double>("AdvancedPaymentLeftToPay")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EnrollmentDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EntireAmountPaymentDate")
                        .HasColumnType("date");

                    b.Property<double>("EntireCostLeftToPay")
                        .HasColumnType("float");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TourId");

                    b.ToTable("CustomersToursRelations");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AdvancePaymentCost")
                        .HasColumnType("float");

                    b.Property<DateOnly>("AdvancePaymentDeadline")
                        .HasColumnType("date");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EntireAmountPaymentDeadline")
                        .HasColumnType("date");

                    b.Property<double>("EntireCost")
                        .HasColumnType("float");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("TimeEnd")
                        .HasColumnType("date");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("TimeStart")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.TravelAgencyCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreatedInUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeLastModifiedInUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("TravelAgencyCustomers");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.CustomersDivingCoursesRelations", b =>
                {
                    b.HasOne("CustomersManagement.Domain.DivingSchool.DivingSchoolCustomer", "Customer")
                        .WithMany("DivingCoursesRelations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomersManagement.Domain.DivingSchool.DivingCourse", "DivingCourse")
                        .WithMany("DivingCourseRelations")
                        .HasForeignKey("DivingCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DivingCourse");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.DivingSchoolCustomer", b =>
                {
                    b.HasOne("CustomersManagement.Domain.Address", "Address")
                        .WithOne("DivingSchoolCustomer")
                        .HasForeignKey("CustomersManagement.Domain.DivingSchool.DivingSchoolCustomer", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.CustomersToursRelations", b =>
                {
                    b.HasOne("CustomersManagement.Domain.TravelAgency.TravelAgencyCustomer", "Customer")
                        .WithMany("ToursRelations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomersManagement.Domain.TravelAgency.Tour", "Tour")
                        .WithMany("TourRelations")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.TravelAgencyCustomer", b =>
                {
                    b.HasOne("CustomersManagement.Domain.Address", "Address")
                        .WithOne("TravelAgencyCustomer")
                        .HasForeignKey("CustomersManagement.Domain.TravelAgency.TravelAgencyCustomer", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CustomersManagement.Domain.Address", b =>
                {
                    b.Navigation("DivingSchoolCustomer");

                    b.Navigation("TravelAgencyCustomer");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.DivingCourse", b =>
                {
                    b.Navigation("DivingCourseRelations");
                });

            modelBuilder.Entity("CustomersManagement.Domain.DivingSchool.DivingSchoolCustomer", b =>
                {
                    b.Navigation("DivingCoursesRelations");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.Tour", b =>
                {
                    b.Navigation("TourRelations");
                });

            modelBuilder.Entity("CustomersManagement.Domain.TravelAgency.TravelAgencyCustomer", b =>
                {
                    b.Navigation("ToursRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
