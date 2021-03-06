// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagement.DB.Models;

#nullable disable

namespace SchoolManagement.DB.Migrations
{
    [DbContext(typeof(SchoolManagementContext))]
    partial class SchoolManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolManagement.DB.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "y1234",
                            UserName = "yehudan"
                        });
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<int?>("ClassCode")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("CrewMemberId")
                        .HasColumnType("int")
                        .HasColumnName("crewMemberId");

                    b.Property<string>("SubjectName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.HasIndex("CrewMemberId");

                    b.ToTable("Class", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Subject")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("CrewMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Adress = "Rakefet 23",
                            City = "Modi'in",
                            Email = "yehudanmanage@gmail.com",
                            FirstName = "Yehuda",
                            Gender = "male",
                            LastName = "Dan",
                            Role = "manager"
                        });
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.HomeWork", b =>
                {
                    b.Property<int>("HwId")
                        .HasColumnType("int")
                        .HasColumnName("HW_Id");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<byte[]>("Hwcontent")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("HWContent");

                    b.Property<DateTime?>("SignDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("HwId");

                    b.HasIndex("StudentId");

                    b.ToTable("HomeWork", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WorkAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Parent", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmergacyContactName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Student_Class", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.StudentParent", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasIndex("ParentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Student_parent", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Class", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.CrewMember", "CrewMember")
                        .WithMany("Classes")
                        .HasForeignKey("CrewMemberId")
                        .HasConstraintName("FK_Class_CrewMembers");

                    b.Navigation("CrewMember");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.CrewMember", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.Account", "Account")
                        .WithMany("CrewMembers")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_CrewMembers_Accounts");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.HomeWork", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.Student", "Student")
                        .WithMany("HomeWorks")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_HomeWork_Student");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Parent", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.Account", "Account")
                        .WithMany("Parents")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Parent_Accounts");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Student", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.Account", "Account")
                        .WithMany("Students")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Student_Accounts");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.StudentClass", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("FK_Student_Class_Class");

                    b.HasOne("SchoolManagement.DB.Models.Student", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Student_Class_Student");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.StudentParent", b =>
                {
                    b.HasOne("SchoolManagement.DB.Models.Parent", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .IsRequired()
                        .HasConstraintName("FK_FamilyConnection_Parent");

                    b.HasOne("SchoolManagement.DB.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_FamilyConnection_Student");

                    b.Navigation("Parent");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Account", b =>
                {
                    b.Navigation("CrewMembers");

                    b.Navigation("Parents");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Class", b =>
                {
                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.CrewMember", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("SchoolManagement.DB.Models.Student", b =>
                {
                    b.Navigation("HomeWorks");

                    b.Navigation("StudentClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
