// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dA.Data;

namespace dA.Data.Migrations
{
    [DbContext(typeof(DoAnContext))]
    [Migration("20221105093854_appblog")]
    partial class appblog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dA.Data.AppCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalProduct")
                        .HasColumnType("int");

                    b.Property<int?>("TrademarkId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TrademarkId");

                    b.ToTable("AppCategorys");
                });

            modelBuilder.Entity("dA.Data.AppCustomer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AppCustomer");
                });

            modelBuilder.Entity("dA.Data.AppPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducId");

                    b.ToTable("AppPictures");
                });

            modelBuilder.Entity("dA.Data.AppProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int?>("Like")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PromoPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Sold")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrademarkId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrlPicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TrademarkId");

                    b.ToTable("AppProducts");
                });

            modelBuilder.Entity("dA.Data.AppSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("AppSizes");
                });

            modelBuilder.Entity("dA.Data.AppTrademark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppTrademarks");
                });

            modelBuilder.Entity("dA.Data.AppUserAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSuper")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUserAdmin");
                });

            modelBuilder.Entity("dA.Data.Entities.AppBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addresss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("AppBills");
                });

            modelBuilder.Entity("dA.Data.Entities.AppBillDetail", b =>
                {
                    b.Property<int>("IdBill")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalProduct")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdBill", "IdProduct");

                    b.HasIndex("IdProduct");

                    b.ToTable("AppBillDetails");
                });

            modelBuilder.Entity("dA.Data.AppCategory", b =>
                {
                    b.HasOne("dA.Data.AppTrademark", "ListTrademark")
                        .WithMany("ListCategory")
                        .HasForeignKey("TrademarkId");

                    b.Navigation("ListTrademark");
                });

            modelBuilder.Entity("dA.Data.AppPicture", b =>
                {
                    b.HasOne("dA.Data.AppProduct", "ListProduct")
                        .WithMany("ListProductPicture")
                        .HasForeignKey("ProducId");

                    b.Navigation("ListProduct");
                });

            modelBuilder.Entity("dA.Data.AppProduct", b =>
                {
                    b.HasOne("dA.Data.AppCategory", "CategoryNavigation")
                        .WithMany("ListProduct")
                        .HasForeignKey("CategoryId");

                    b.HasOne("dA.Data.AppTrademark", "TrademarkNavigation")
                        .WithMany("ListProduct")
                        .HasForeignKey("TrademarkId");

                    b.Navigation("CategoryNavigation");

                    b.Navigation("TrademarkNavigation");
                });

            modelBuilder.Entity("dA.Data.AppSize", b =>
                {
                    b.HasOne("dA.Data.AppProduct", "Product")
                        .WithMany("ListSizeNavigation")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("dA.Data.Entities.AppBillDetail", b =>
                {
                    b.HasOne("dA.Data.Entities.AppBill", "IdBillNavigation")
                        .WithMany("AppBillDetailtNavigation")
                        .HasForeignKey("IdBill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dA.Data.AppProduct", "BillProduct")
                        .WithMany("AppBillDetailtNavigation")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillProduct");

                    b.Navigation("IdBillNavigation");
                });

            modelBuilder.Entity("dA.Data.AppCategory", b =>
                {
                    b.Navigation("ListProduct");
                });

            modelBuilder.Entity("dA.Data.AppProduct", b =>
                {
                    b.Navigation("AppBillDetailtNavigation");

                    b.Navigation("ListProductPicture");

                    b.Navigation("ListSizeNavigation");
                });

            modelBuilder.Entity("dA.Data.AppTrademark", b =>
                {
                    b.Navigation("ListCategory");

                    b.Navigation("ListProduct");
                });

            modelBuilder.Entity("dA.Data.Entities.AppBill", b =>
                {
                    b.Navigation("AppBillDetailtNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
