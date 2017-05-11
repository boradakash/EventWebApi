using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EventApplication.Models;

namespace EventApplication.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventApplication.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventApplication.Models.EventDate", b =>
                {
                    b.Property<int>("EventDateId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("EventId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("EventDateId");

                    b.HasIndex("EventId");

                    b.ToTable("EventDates");
                });

            modelBuilder.Entity("EventApplication.Models.EventDateParticipant", b =>
                {
                    b.Property<int>("EventDateParticipantId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventDateId");

                    b.Property<int>("ParticipantId");

                    b.HasKey("EventDateParticipantId");

                    b.HasIndex("EventDateId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("EventDateParticipants");
                });

            modelBuilder.Entity("EventApplication.Models.EventDescription", b =>
                {
                    b.Property<int>("EventDescriptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventDesciption")
                        .IsRequired();

                    b.Property<int>("EventId");

                    b.HasKey("EventDescriptionId");

                    b.HasIndex("EventId");

                    b.ToTable("EventDescriptions");
                });

            modelBuilder.Entity("EventApplication.Models.EventImage", b =>
                {
                    b.Property<int>("EventImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.HasKey("EventImageId");

                    b.HasIndex("EventId");

                    b.ToTable("EventImages");
                });

            modelBuilder.Entity("EventApplication.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.HasKey("ParticipantId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("EventApplication.Models.EventDate", b =>
                {
                    b.HasOne("EventApplication.Models.Event", "Event")
                        .WithMany("EventDates")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventApplication.Models.EventDateParticipant", b =>
                {
                    b.HasOne("EventApplication.Models.EventDate", "EventDate")
                        .WithMany("EventDateParticipants")
                        .HasForeignKey("EventDateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventApplication.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventApplication.Models.EventDescription", b =>
                {
                    b.HasOne("EventApplication.Models.Event", "Event")
                        .WithMany("EventDescriptions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventApplication.Models.EventImage", b =>
                {
                    b.HasOne("EventApplication.Models.Event", "Event")
                        .WithMany("EventImages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
