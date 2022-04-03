﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UCS.DbProvider;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GradeQuestion", b =>
                {
                    b.Property<int>("GradesId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.HasKey("GradesId", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("GradeQuestion");
                });

            modelBuilder.Entity("GroupSubject", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("GroupSubject");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("GradeNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FacultyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<byte[]>("ImageBytes")
                        .HasColumnType("bytea");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UploadDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<int>("QuestionThemeId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("QuestionThemeId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("TopicId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.QuestionTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuestionThemes");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.SessionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<int?>("GradeId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("TestSessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("ImageId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TestSessionId");

                    b.ToTable("SessionAnswers");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.TestSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FinishDatetime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDatetime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TimeLimitDatetime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("TestSessions");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("TimeLimit")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.TopicRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionThemeId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionsCount")
                        .HasColumnType("integer");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionThemeId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("TopicId");

                    b.ToTable("TopicRule");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Ages")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GradeQuestion", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Grade", null)
                        .WithMany()
                        .HasForeignKey("GradesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupSubject", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Chapter", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Subject", "Subject")
                        .WithMany("Chapters")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Group", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Question", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Image", "Image")
                        .WithMany("Questions")
                        .HasForeignKey("ImageId");

                    b.HasOne("UCS.DbProvider.Models.QuestionTheme", "QuestionTheme")
                        .WithMany()
                        .HasForeignKey("QuestionThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.Topic", "Topic")
                        .WithMany("Questions")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("QuestionTheme");

                    b.Navigation("QuestionType");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.SessionAnswer", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Grade", "Grade")
                        .WithMany("SessionAnswers")
                        .HasForeignKey("GradeId");

                    b.HasOne("UCS.DbProvider.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("UCS.DbProvider.Models.Question", "Question")
                        .WithMany("SessionAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.TestSession", "TestSession")
                        .WithMany("Answers")
                        .HasForeignKey("TestSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Image");

                    b.Navigation("Question");

                    b.Navigation("TestSession");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.TestSession", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Topic", "Topic")
                        .WithMany("Sessions")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Topic", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Chapter", "Chapter")
                        .WithMany("Topics")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.TopicRule", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.QuestionTheme", "QuestionTheme")
                        .WithMany("TopicRules")
                        .HasForeignKey("QuestionThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.QuestionType", "QuestionType")
                        .WithMany("TopicRules")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCS.DbProvider.Models.Topic", "Topic")
                        .WithMany("TopicRules")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionTheme");

                    b.Navigation("QuestionType");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.User", b =>
                {
                    b.HasOne("UCS.DbProvider.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Chapter", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Faculty", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Grade", b =>
                {
                    b.Navigation("SessionAnswers");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Image", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Question", b =>
                {
                    b.Navigation("SessionAnswers");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.QuestionTheme", b =>
                {
                    b.Navigation("TopicRules");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.QuestionType", b =>
                {
                    b.Navigation("TopicRules");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Subject", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.TestSession", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("UCS.DbProvider.Models.Topic", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Sessions");

                    b.Navigation("TopicRules");
                });
#pragma warning restore 612, 618
        }
    }
}
