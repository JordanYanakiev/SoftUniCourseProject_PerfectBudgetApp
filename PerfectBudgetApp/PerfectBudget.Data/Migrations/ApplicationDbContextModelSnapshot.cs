﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfectBudgetApp.Data;

#nullable disable

namespace PerfectBudgetApp.Data.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Groceries"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Car"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Loan"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Internet"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mobile"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Leasing"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Electricity"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Water"
                        });
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.DebtIssuer", b =>
                {
                    b.Property<Guid>("DebtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DebtIssuerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DebtId", "DebtIssuerId");

                    b.HasIndex("DebtIssuerId");

                    b.ToTable("DebtsIssuers");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.DebtReceiver", b =>
                {
                    b.Property<Guid>("DebtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DebtReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DebtId", "DebtReceiverId");

                    b.HasIndex("DebtReceiverId");

                    b.ToTable("DebtsReceivers");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "ExpenseId");

                    b.HasIndex("ExpenseId");

                    b.ToTable("ExpenseCategory");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.Saving", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Savings");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.UserSaving", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("SavingsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "SavingsId");

                    b.HasIndex("SavingsId");

                    b.ToTable("UsersSavings");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Budgets");

                    b.HasComment("Every budget has custom name");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.BudgetExpense", b =>
                {
                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BudgetId", "ExpenseId");

                    b.HasIndex("ExpenseId");

                    b.ToTable("BudgetsExpenses");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.Debt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoanGiver")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LoanRequester")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.DebtPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CreditInstallment")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DebtPayment");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.DebtPaymentDebt", b =>
                {
                    b.Property<Guid>("DebtInstallmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DebtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DebtInstallmentId", "DebtId");

                    b.HasIndex("DebtId");

                    b.ToTable("DebtPaymentDebt");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfIssuedExpense")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.UserBudget", b =>
                {
                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BudgetId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersBudgets");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.UserDebt", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("DebtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "DebtId");

                    b.HasIndex("DebtId");

                    b.ToTable("UsersDebts");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.UserExpense", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ExpenseId");

                    b.HasIndex("ExpenseId");

                    b.ToTable("UsersExpenses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.DebtIssuer", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Debt", "Debt")
                        .WithMany()
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UserId")
                        .WithMany()
                        .HasForeignKey("DebtIssuerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.DebtReceiver", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Debt", "Debt")
                        .WithMany()
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UserId")
                        .WithMany()
                        .HasForeignKey("DebtReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.ExpenseCategory", b =>
                {
                    b.HasOne("PerfectBudget.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerfectBudgetApp.Data.Models.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Expense");
                });

            modelBuilder.Entity("PerfectBudget.Data.Models.UserSaving", b =>
                {
                    b.HasOne("PerfectBudget.Data.Models.Saving", "Saving")
                        .WithMany()
                        .HasForeignKey("SavingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Saving");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.BudgetExpense", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Budget", "Budget")
                        .WithMany("BudgetsExpenses")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PerfectBudgetApp.Data.Models.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Expense");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.Debt", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Budget", null)
                        .WithMany("BudgetDebtList")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.DebtPaymentDebt", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Debt", "Debt")
                        .WithMany()
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerfectBudgetApp.Data.Models.DebtPayment", "DeptPayment")
                        .WithMany()
                        .HasForeignKey("DebtInstallmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");

                    b.Navigation("DeptPayment");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.Expense", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Budget", "Budget")
                        .WithMany("BudgetExpenseList")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerfectBudget.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.UserBudget", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.UserDebt", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Debt", "Debt")
                        .WithMany()
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.UserExpense", b =>
                {
                    b.HasOne("PerfectBudgetApp.Data.Models.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expense");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectBudgetApp.Data.Models.Budget", b =>
                {
                    b.Navigation("BudgetDebtList");

                    b.Navigation("BudgetExpenseList");

                    b.Navigation("BudgetsExpenses");
                });
#pragma warning restore 612, 618
        }
    }
}
