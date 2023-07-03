﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeckOfCards.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("DeckOfCardsLibrary.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeckId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Suit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CardId");

                    b.HasIndex("DeckId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("DeckOfCardsLibrary.Deck", b =>
                {
                    b.Property<int>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeckId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("DeckOfCardsLibrary.Card", b =>
                {
                    b.HasOne("DeckOfCardsLibrary.Deck", null)
                        .WithMany("Cards")
                        .HasForeignKey("DeckId");
                });

            modelBuilder.Entity("DeckOfCardsLibrary.Deck", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}