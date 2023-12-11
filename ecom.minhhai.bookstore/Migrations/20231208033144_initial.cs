using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecom.minhhai.bookstore.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordering = table.Column<int>(type: "int", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemaMarkup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameWithType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Levels = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pubished = table.Column<bool>(type: "bit", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ordering = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "TransactStatus",
                columns: table => new
                {
                    TransactStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactStatus", x => x.TransactStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BestSellers = table.Column<bool>(type: "bit", nullable: false),
                    HomeFlag = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    OriginalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    District = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ward = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avarta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Lastlogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ward = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    District = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: true),
                    TransactStatusId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                    table.ForeignKey(
                        name: "FK_Orders_TransactStatus_TransactStatusId",
                        column: x => x.TransactStatusId,
                        principalTable: "TransactStatus",
                        principalColumn: "TransactStatusId");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHot = table.Column<bool>(type: "bit", nullable: false),
                    IsNewFeed = table.Column<bool>(type: "bit", nullable: false),
                    MetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View = table.Column<int>(type: "int", nullable: true),
                    AccountModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AccountModelId",
                        column: x => x.AccountModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Quanlity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailModelId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5B71C14D-AEDB-41E1-A1D9-943FD5D3983C", "24068b2f-f3f1-4bd3-9c93-45f449fa2398", "Administrator", "ADMINISTRATOR" },
                    { "E9BB47A8-D3FC-409C-8651-0542816F7483", "4d0de3ef-9951-4afb-b814-c36b6fd0017c", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "Address", "Avarta", "ConcurrencyStamp", "CreateDate", "District", "Email", "EmailConfirmed", "FullName", "Lastlogin", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Ward" },
                values: new object[] { "9C0AA3D8-C892-4407-9521-3BBFA5B05D0A", 0, true, null, null, "d8848403-14c8-4082-8e0f-129450eecaa7", null, null, "admin@gmail.com", true, null, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, "AQAAAAEAACcQAAAAEEWdpiMHP9GmuG6XNJrbcOABvobM274VR6kpsVlfCGzTfPcgqhZ5lvu/llJEXIjbSA==", null, false, "397208ba-2e44-4f04-9526-b466a456fd0b", false, "admin@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Alias", "CategoryName", "Cover", "MetaDesc", "MetaKey", "Ordering", "Published", "SchemaMarkup", "Title" },
                values: new object[,]
                {
                    { new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), null, "Fantasy", null, null, null, null, false, null, null },
                    { new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), null, "Fiction", null, null, null, null, false, null, null },
                    { new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), null, "Comics", null, null, null, null, false, null, null },
                    { new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), null, "Romance", null, null, null, null, false, null, null },
                    { new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), null, "Horror", null, null, null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Levels", "Name", "NameWithType", "Parent", "Slug", "Type" },
                values: new object[,]
                {
                    { new Guid("00126057-e038-454a-8022-ac430fc6a92b"), 3, "Quang Trung", "Phường Quang Trung", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("002ce0d8-c4c2-4a4f-a45c-c39533254448"), 3, "Vĩnh Nguyên", "Phường Vĩnh Nguyên", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("008a179e-c7eb-4945-a3a9-9e93e692beac"), 3, "Khánh Hiệp", "Xã Khánh Hiệp", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("01219813-929c-4704-a6eb-6cffeae732ee"), 3, "Phường 11", "Phường 11", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), 1, "Đà Nẵng", "TP.Đà Nẵng", null, null, "Tỉnh/Thành" },
                    { new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), 2, "Bình Thạnh", "Quận Bình Thạnh", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("018b77b5-53bd-4307-9d53-dbb774c4c77d"), 3, "Thạnh Lộc", "Phường Thạnh Lộc", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("018ec29a-03a7-4b64-9434-579097a87249"), 3, "Phường 4", "Phường 4", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("02253daa-410a-4711-979e-557f74b7ece6"), 3, "Phước Mỹ", "Phường Phước Mỹ", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("025466f1-c369-4551-aa42-0baab60eb70f"), 3, "Đức Giang", "Phường Đức Giang", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("02a2afb3-4e93-4a63-9924-83db8cc72ae6"), 3, "Hàng Mã", "Phường Hàng Mã", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("02ae535e-3233-44f0-9e2f-7d72abe03fcf"), 3, "4", "Phường 4", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("031acf01-3d0a-451f-ac75-1fe637efbaf9"), 3, "1", "Phường 1", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("04831368-dcb6-4c94-b427-0c26c2171a75"), 3, "Thạnh Mỹ Lợi", "Phường Thạnh Mỹ Lợi", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("04f947a1-1a68-46ec-99e1-969e48c4c887"), 3, "Đồng Xuân", "Phường Đồng Xuân", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("0504e47e-04a5-4542-a54f-0311435b81d3"), 3, "Phường 7", "Phường 7", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("057d6923-3fe9-474b-b5d1-d5269dba48dc"), 3, "10", "Phường 10", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("05e16b0f-27c3-4086-8994-b53779fa4675"), 3, "Phường 10", "Phường 10", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("06321b26-3f0f-4fd0-a44e-e45f3fceee17"), 3, "Đông Ngạc", "Phường Đông Ngạc", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("068f84d1-bbfa-4500-b01f-1ec34eb81573"), 3, "Hợp Đồng", "Xã Hợp Đồng", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("072f7691-8645-4caa-aa6a-623bd65b8f95"), 3, "8", "Phường 8", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("07409976-43da-4ea2-85c1-6a32e5538ec8"), 3, "Thanh Lương", "Phường Thanh Lương", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("08270d46-e5e1-4ece-9cf1-e12340946073"), 3, "Mỹ Lương", "Xã Mỹ Lương", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("0986ab4a-4bd3-4e16-9e57-be7b2d90ede9"), 3, "Bình Hiên", "Phường Bình Hiên", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), 1, "Khánh Hòa", "Tỉnh Khánh Hòa", null, null, "Tỉnh/Thành" },
                    { new Guid("0a04022d-5afe-4422-bf8f-77aa3e48c3f9"), 3, "Quán Thánh", "Phường Quán Thánh", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("0a11d229-6fb6-4924-9c95-f2b8186271dd"), 3, "Thịnh Liệt", "Phường Thịnh Liệt", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("0a303310-a031-49fd-904d-193d5c50d533"), 3, "5", "Phường 5", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("0a816e59-bd70-4358-9506-fb67163f61d9"), 3, "Hàng Gai", "Phường Hàng Gai", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("0a89240b-932e-4cfa-a214-711ddb7ffdab"), 3, "Phúc Xá", "Phường Phúc Xá", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("0ae9e4eb-c450-4085-bc67-4dded65ed1a4"), 3, "Tân Tiến", "Xã Tân Tiến", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("0b8456d5-e374-4f84-a5e2-432004237879"), 3, "Phan Chu Trinh", "Phường Phan Chu Trinh", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("0ba52296-cadb-4632-bbcd-8d821d4edf1d"), 3, "Phường 5", "Phường 5", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("0bd79acb-542a-45d4-9ef5-d9261a586684"), 3, "Bắc Hồng", "Xã Bắc Hồng", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("0bdf4176-f149-49cf-9571-b6f9ea66508e"), 3, "Diên Bình", "Xã Diên Bình", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("0c6dd1a5-d946-41db-8957-fff5ad2b0ed1"), 3, "Liên Hồng", "Xã Liên Hồng", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("0cd85fe3-0014-4f47-a70c-ebcf9bdf1704"), 3, "13", "Phường 13", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("0d6a4b2b-6884-47ad-872b-8ea894a71da4"), 3, "Ba Vì", "Xã Ba Vì", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("0d8b803b-d6ec-40c8-a187-e43aac1edcde"), 3, "2", "Phường 2", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("0e41b6bc-00eb-4ce9-82ad-71312e33e6dc"), 3, "Phú Lương", "Phường Phú Lương", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("0e549bc9-2f1e-4814-8976-0c6e6bcfd838"), 3, "Bạch Mai", "Phường Bạch Mai", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("0e59aa17-5d58-47ce-ba90-fa1096960b52"), 3, "Yết Kiêu", "Phường Yết Kiêu", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("0ea7928c-a39b-4349-96a1-e62e3d6894c0"), 3, "Đồng Mai", "Phường Đồng Mai", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("0f3ee201-b29d-402d-bedd-ac70f04245cd"), 3, "Vạn Phúc", "Phường Vạn Phúc", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("0f889415-8015-4d23-a91b-05750d851638"), 3, "Minh Khai", "Phường Minh Khai", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("113735dd-241a-4b32-8303-761c3f48a3cc"), 3, "Phường 15", "Phường 15", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("12a6360b-89e6-47f4-85ce-ffbe8a7c35c6"), 3, "Hồng Hà", "Xã Hồng Hà", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("13c1ddbd-bed4-42bc-9dcb-b16cd52c6e60"), 3, "Liên Mạc", "Phường Liên Mạc", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("14240f4b-55de-40ce-9817-23681bad84ce"), 3, "Cam Thượng", "Xã Cam Thượng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("143ee519-a0cd-483b-9bdb-04bec8698977"), 3, "Tây Mỗ", "Phường Tây Mỗ", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("1481a070-1ae0-4240-9825-646bc91a04b8"), 3, "Phường 9", "Phường 9", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("14ab8297-c89f-4c1e-96cb-6bf43680d9c8"), 3, "Khuê Trung", "Phường Khuê Trung", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("150b3d34-0192-42c4-bf92-74c2cb55d1c4"), 3, "Vĩnh Trung", "Phường Vĩnh Trung", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), 2, "11", "Quận 11", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("1671dfbe-1cff-4008-a694-8de78d1b10d3"), 3, "Phường 8", "Phường 8", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("16814b2a-f020-4631-bc0c-43e0ae02217f"), 3, "Lê Hồng Phong", "Phường Lê Hồng Phong", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("170285fb-89d7-4667-bee2-06a8f4dc47e2"), 3, "Linh Trung", "Phường Linh Trung", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("17162c46-61a3-49b0-bc87-7db56b349a30"), 3, "Phước Ninh", "Phường Phước Ninh", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("171b8a4f-911b-461e-9c8e-8e1a114b1e9b"), 3, "Bình An", "Phường Bình An", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("173c83c3-531a-41d8-af4f-184e33f04335"), 3, "Bến Thành", "Phường Bến Thành", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("176c585f-7bad-45fe-9f99-85de230868e8"), 3, "5", "Phường 5", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("1779be7b-19c2-4471-b725-df20721d1615"), 3, "Vĩnh Tuy", "Phường Vĩnh Tuy", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("17aa5f05-5fc9-4598-8cec-086b9e3907b6"), 3, "Hàng Đào", "Phường Hàng Đào", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("17d7f837-f148-4732-aec8-39c63c94e5ec"), 3, "Phước Hòa", "Phường Phước Hòa", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("19152119-fa9a-417c-b320-e7ef63e09ffb"), 3, "11", "Phường 11", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("19810767-e8c1-4630-b252-aefc14c9706a"), 3, "Đồng Tâm", "Phường Đồng Tâm", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("1a10df14-ab42-4ad1-b139-7513e83c5a00"), 3, "6", "Phường 6", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), 2, "Nha Trang", "TP.Nha Trang", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("1b22840d-86e2-4c55-9d70-8dc9f3b917d1"), 3, "Phong Vân", "Xã Phong Vân", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("1bbfa73a-d410-4145-83cd-b739a568b39f"), 3, "Bình Thuận", "Phường Bình Thuận", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("1be10c86-576c-4026-a9f1-b2600b70ebed"), 3, "Mỹ An", "Phường Mỹ An", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("1c9626ad-1426-4868-af7f-89e767acc0d2"), 3, "Phường 2", "Phường 2", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("1c9d8f35-5643-4319-9f34-85c9749d4ddd"), 3, "Phương Liệt", "Phường Phương Liệt", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("1c9fee44-2e2e-4152-815d-ff9ac2b3aaf5"), 3, "Phường 7", "Phường 7", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("1cced1f2-4688-47af-87f9-dd1e63b02487"), 3, "Phạm Đình Hổ", "Phường Phạm Đình Hổ", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("1cf330ea-8ed4-4be3-a7d5-36877c456f13"), 3, "Dịch Vọng Hậu", "Phường Dịch Vọng Hậu", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("1cfa5a5b-0ae5-46b5-a85d-0bdee086aaaf"), 3, "Trung Hòa", "Xã Trung Hòa", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("1d145973-fd6d-4e06-9e93-10b63e0225c9"), 3, "12", "Phường 12", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("1d234822-367c-4c8e-8884-be55e82de9ba"), 3, "Thổ Quan", "Phường Thổ Quan", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), 2, "Thủ Đức", "Quận Thủ Đức", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("1dc76788-284a-4798-9e6e-972abd3d5fb4"), 3, "Trung Văn", "Phường Trung Văn", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("1e8b9f2d-d5db-46f6-8e48-f652a5821143"), 3, "Hòa Thọ Tây", "Phường Hòa Thọ Tây", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("1e98ac87-8828-411e-abbd-6341525628a9"), 3, "Hàng Buồm", "Phường Hàng Buồm", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("1ed90642-7a73-46cc-8b7c-5788d6ddfbd7"), 3, "Thuận Phước", "Phường Thuận Phước", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("1f01486e-b2eb-4ed4-a37a-185559bdff23"), 3, "Nguyễn Cư Trinh", "Phường Nguyễn Cư Trinh", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("208cc21e-794e-4e25-aabf-ebacc0d23541"), 3, "Phú Thuận", "Phường Phú Thuận", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("212317b4-eb83-41b6-8027-798b5c8a94ce"), 3, "Khương Thượng", "Phường Khương Thượng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), 2, "Đan Phương", "Huyện Đan Phương", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("21cc6bdc-1057-4b58-9871-da2999e8751a"), 3, "Tăng Nhơn Phú A", "Phường Tăng Nhơn Phú A", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("223b6867-955f-4168-bb70-ba09ed57bc3a"), 3, "3", "Phường 3", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("2366d7d5-4710-4275-8b45-5a158c807223"), 3, "Đồng Tháp", "Xã Đồng Tháp", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("23a929cb-1ce5-483c-baea-85077f8ea81c"), 3, "Hòa Khê", "Phường Hòa Khê", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("24043de2-a046-4ab5-99b5-3c1a005ac198"), 3, "Trung Mỹ Tây", "Phường Trung Mỹ Tây", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("245f5d0b-f1f2-4e31-b529-73c20f502376"), 3, "Vĩnh Lương", "Xã Vĩnh Lương", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("24a7c372-520a-439f-9d5d-adc2fff7fe7c"), 3, "Dịch Vọng", "Phường Dịch Vọng", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), 2, "Hồng Lĩnh", "Thị xã Hồng Lĩnh", new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), null, "Thị xã" },
                    { new Guid("257ed683-207f-4810-8421-c0ad8120a7bf"), 3, "Thanh Khê Đông", "Phường Thanh Khê Đông", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), 2, "Gò Vấp", "Quận Gò Vấp", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("2677cd46-5c06-454a-86a2-8d72cb7c876e"), 3, "12", "Phường 12", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("27d02bc0-098d-46e0-8ef7-f843d80f3db5"), 3, "Cát Linh", "Phường Cát Linh", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("27f54394-73b6-4eff-a5ac-29bb7201fa66"), 3, "Trần Hưng Đạo", "Phường Trần Hưng Đạo", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("283ca78b-66ab-4ef3-ad8b-293706c3906a"), 3, "Hòa Phú", "Phường Hòa Phú", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("28b32d08-ed7a-4004-8f7c-23a4a88d5ac4"), 3, "Quỳnh Lôi", "Phường Quỳnh Lôi", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("28ca8c15-6f37-437e-abaf-d2243a090f5f"), 3, "Mỹ An", "Phường Mỹ An", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("28dbcdf0-ff87-4889-8420-8ed8366e932e"), 3, "Hòa An", "Phường Hòa An", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("291b2733-f81f-479f-b516-23ea7cfc4b52"), 3, "Chu Minh", "Xã Chu Minh", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), 2, "Thanh Xuân", "Quận Thanh Xuân", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("29c373e5-37f6-4024-b3c5-70ddcb31a31d"), 3, "Thượng Vực", "Xã Thượng Vực", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("2a74aa04-3ef2-4444-8c6c-846ed1f65b42"), 3, "Phường 7", "Phường 7", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("2a82671d-fd5b-4048-b29e-69447b697fbb"), 3, "Liên Trung", "Xã Liên Trung", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("2ad61052-112e-4420-9b46-52b75b85489f"), 3, "Đại Yên", "Xã Đại Yên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("2b7cf31e-456d-4674-827e-0868120da973"), 2, "Đông Anh", "Huyện Đông Anh", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("2c114045-eb1a-4797-8b48-f45b7af91bf1"), 3, "14", "Phường 14", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("2d01f2f2-10a8-4273-a431-8370ef561c9f"), 3, "Hương Xuân", "Phường Hương Xuân", new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), null, "Phường/Xã" },
                    { new Guid("2d5daf4f-3c35-44b1-9ff1-20978ac05114"), 3, "Thạch Thang", "Phường Thạch Thang", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("2dcecd20-ff80-401c-bbf1-308a2a3ccbb4"), 3, "Bồ Xuyên", "Phường Bồ Xuyên", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("2e23f390-763d-4428-a03c-70dd2f6d662f"), 3, "9", "Phường 9", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("2e604086-8079-4202-8994-88c3c22a967a"), 3, "Mân Thái", "Phường Mân Thái", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("2eb45eff-1c29-43c4-b40c-045a396a1a92"), 3, "Long Biên", "Phường Long Biên", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("2ef4fcfd-315d-425e-a625-9e3226fe0866"), 3, "Thượng Đình", "Phường Thượng Đình", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("2f18eea3-ffa1-40a4-a06d-c0e1a619999e"), 3, "Cổ Huế 1", "Phường Cổ Huế 1", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("2fd08d75-d7a1-488f-940b-6715205a0059"), 3, "Phường 5", "Phường 5", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("3010c651-5f9a-4dd5-8540-9e5e5fa8df66"), 3, "Phương Sài", "Phường Phương Sài", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), 2, "Tân Bình", "Quận Tân Bình", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("311b7fbc-c01a-45f4-921c-c8a189d322bc"), 3, "Thụy Hương", "Xã Thụy Hương", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("313e674b-a6f6-44d7-8f25-75432aaa9586"), 3, "11", "Phường 11", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("31986712-873e-46fa-a269-dc8bcf575268"), 3, "Nghĩa Tân", "Phường Nghĩa Tân", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("31fbf790-96a0-4585-b46d-afd934bba1ff"), 3, "Xuân Hà", "Phường Xuân Hà", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("3214a901-5aad-48b1-bf5a-45358cc64701"), 3, "Hòa Xuân", "Phường Hòa Xuân", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("32793b17-74a6-4309-b2ae-efa028d4a2e1"), 3, "Tân Quy", "Phường Tân Quy", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("3387e056-9678-4a8d-8461-687da1c76310"), 3, "13", "Phường 13", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("33bc8a62-372e-49c4-af60-a43ef1bbeca9"), 3, "Mỹ Đình 1", "Phường Mỹ Đình 1", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("34be5b8c-a1f0-4160-a802-a49d2884ca00"), 3, "Tân Kiểng", "Phường Tân Kiểng", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("34f9b16e-a8e4-4526-91c2-7cc564ab7ac0"), 3, "Khánh Thượng", "Xã Khánh Thượng", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("357f060a-2085-4a8a-9039-c6b625e43029"), 3, "Trần Hưng Đạo", "Phường Trần Hưng Đạo", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("35bbd341-7de9-4b93-b38e-d389a78bb635"), 3, "Hàng Trống", "Phường Hàng Trống", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("3682ee5d-a972-48dc-8227-0a31e877901c"), 3, "Thủ Thiêm", "Phường Thủ Thiêm", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("36e5fccb-124e-41bb-b326-79ac0ee228ec"), 3, "2", "Phường 2", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("372e12eb-5f74-4fea-bf67-4cb461374c6f"), 3, "Mỹ Đa", "Phường Mỹ Đa", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("377df2e1-1a4a-4823-bec4-22b869706d1d"), 3, "Tân Thuận Tây", "Phường Tân Thuận Tây", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("380c78cd-3c46-40ae-8ff8-720a5200388c"), 3, "Đông Phương Yên", "Xã Đông Phương Yên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("3830d731-0ea2-45be-9a86-05b4654612c2"), 3, "Cô Giang", "Phường Cô Giang", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("38da834b-3ec3-4aad-9c18-8418ba0ea2b6"), 3, "Hồng Phong", "Xã Hồng Phong", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("39469946-b2c3-44af-860b-3c5538f45b5a"), 3, "Đại Kim", "Phường Đại Kim", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("399bc56c-cb0f-4792-b5ab-cc27fca38c09"), 3, "Bắc Hà", "Phường Bắc Hà", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("39ccb16b-f577-45aa-bfc3-75c5e76950ef"), 3, "Phú Sơn", "Xã Phú Sơn", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("3a8e88cf-9d5d-489a-a0cd-fb8f7c93a42a"), 3, "11", "Phường 11", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("3aa263f4-845a-4600-98c7-334f82679d9a"), 3, "Ngọc Hiệp", "Phường Ngọc Hiệp", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("3aea2af6-6519-4586-a862-b0e20fda4c42"), 3, "Thịnh Quang", "Phường Thịnh Quang", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("3afa7e67-5753-44c5-b360-d0c63684cd71"), 3, "10", "Phường 10", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("3b5bba9a-0eac-4ef4-af3c-8e532d6d3926"), 3, "Minh Quang", "Xã Minh Quang", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("3b659852-9409-43bd-8737-4c7bb478fb0c"), 3, "Hưng Lộc", "Phường Hưng Lộc", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("3ce3a98f-64fe-49d9-9f64-7b7a20303782"), 3, "Phúc Lợi", "Phường Phúc Lợi", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("3d1625a2-ca4f-4605-a006-6333d61172b0"), 3, "Cam Thuận", "Phường Cam Thuận", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("3d644be8-1355-4c48-8c18-c14709784fef"), 3, "Phường 4", "Phường 4", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("3dcf3a57-d966-46e7-a241-148799f7c1b8"), 3, "Phú Nghĩa", "Xã Phú Nghĩa", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("3ded1671-1232-4df1-a0b0-caa344906e85"), 3, "Phường 13", "Phường 13", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("3e880182-c065-45b8-8e45-a04e74e30e3c"), 3, "10", "Phường 10", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("3e9ae904-d7f9-49c3-874b-25fde1dcc394"), 3, "Phường 1", "Phường 1", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("3f3d61a3-9b42-4596-914f-4ee0712fe261"), 3, "Linh Trung", "Phường Linh Trung", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("3f49f407-dd6c-435c-8e1c-4a2ec1a1840f"), 3, "12", "Phường 12", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("3f6b66b1-bd9e-4a7f-807f-cd3a6f1b226e"), 3, "Tân Thới Nhất", "Phường Tân Thới Nhất", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("405aa03f-8a08-4cc1-880d-5c70fa238542"), 3, "Yên Nghĩa", "Phường Yên Nghĩa", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("42b47a9c-f375-468a-9883-db4ad28a0686"), 3, "Phường 11", "Phường 11", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("42bcd4de-88a4-4155-9018-8743e57e10da"), 3, "Phú Lãm", "Phường Phú Lãm", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("42f146fb-cf76-46e9-b7aa-81cb3fc16c43"), 3, "Văn Nội", "Xã Văn Nội", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("43aa5870-bbe6-41de-9c40-2ad7e9679f80"), 3, "Thọ Trung", "Xã Thọ Trung", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("44183344-6c8f-4e65-9089-8cd18db6e1fe"), 3, "Hàng Bột", "Phường Hàng Bột", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("44407e0f-2157-49a1-b48d-aa2872303461"), 3, "Phước Tân", "Phường Phước Tân", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("44a3c091-945a-4086-80fc-9a68a9dbdec5"), 3, "Thái Hòa", "Xã Thái Hòa", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("44bc47f2-a68c-4ce5-9d4c-c95144907d7d"), 3, "Tản Lĩnh", "Xã Tản Lĩnh", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("44f540bb-2186-452e-89c2-664f6e8ee7f1"), 3, "Cửa Đông", "Phường Cửa Đông", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), 2, "Ba Vì", "Huyện Ba Vì", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("45f48e49-0d1f-4379-ade5-a461d8a39d21"), 3, "Hòa Hiệp Nam", "Phường Hòa Hiệp Nam", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("46420156-4760-4fcb-a9ac-a856e7d059fc"), 3, "Diên Lộc", "Xã Diên Lộc", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("464dd9e3-9933-49c5-a9c8-2ca6e752b65a"), 3, "Tăng Nhơn Phú B", "Phường Tăng Nhơn Phú B", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("46d81116-2597-4fb3-8563-dace8bafe6cd"), 3, "11", "Phường 11", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("4759861f-ee32-499b-a7cc-86f8bfef6549"), 3, "Phú Diễn", "Phường Phú Diễn", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("476582ea-2f5f-41f2-af75-dd390624171f"), 3, "Hòa Phát", "Phường Hòa Phát", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("476d78c7-0bf8-436a-a6cd-483b526ce091"), 3, "Thới An", "Phường Thới An", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("4777bf80-a879-4e7c-9c53-5ca32e4ff4bd"), 3, "Bình Trưng Đông", "Phường Bình Trưng Đông", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("4782862f-c8e9-4501-b482-bc9b8c0ffe32"), 3, "Khâm Thiên", "Phường Khâm Thiên", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("4798371b-ba48-4d66-a11e-37442fa00674"), 3, "Phường 17", "Phường 17", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("47a48eb6-f986-4702-9260-ea1d095f6cd5"), 3, "Ngọc Lâm", "Phường Ngọc Lâm", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("47b64814-63db-46ee-b384-4da0700dbf78"), 3, "Phường 2", "Phường 2", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("480d060c-089d-4e1d-ad2e-17be05f00509"), 3, "6", "Phường 6", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("48d8a5d9-5067-4298-82eb-5b6582b13466"), 3, "8", "Phường 8", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("48d96695-0468-4e38-978e-b11cd1d5c505"), 3, "Khánh Bình", "Xã Khánh Bình", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("49a31a33-2137-4e55-9345-1197103b429a"), 2, "3", "Quận 3", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("49e43878-dd75-4548-82ad-b061449d310f"), 3, "7", "Phường 7", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("4a4052d3-a162-4921-ae8b-1f66d7dac720"), 3, "Quảng Bị", "Xã Quảng Bị", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("4afc7bd8-1fcf-402d-989a-29ba5cf475b2"), 3, "Đông Hưng Thuận", "Phường Đông Hưng Thuận", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("4bef3d2d-1acb-45d4-8ac8-33c8ab44fa55"), 3, "Đại Mỗ", "Phường Đại Mỗ", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("4bf7fbce-8c6a-44e9-9345-d1c90bb84edb"), 3, "Sông Cầu", "Xã Sông Cầu", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("4bff6d4c-95e8-4ed2-aa1d-11ccc5508d8e"), 3, "16", "Phường 16", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("4c042e45-709f-4da5-9164-ee2a177b6905"), 3, "5", "Phường 5", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("4c3a184f-5b99-4d8c-a6dc-6ecbcdd3ea1f"), 3, "Bình Thuận", "Phường Bình Thuận", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("4c830184-e779-4880-8940-29de81c9f84a"), 3, "Yên Hòa", "Phường Yên Hòa", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("4cf813ba-1fdb-48aa-91fc-bfcc1b62cd94"), 3, "Khánh Trung", "Xã Khánh Trung", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("4cffbd63-7804-4df6-b1cf-d06f68864c9c"), 3, "Diên An", "Xã Diên An", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("4da365e3-fba0-4288-a03b-d72f1c8db1f9"), 3, "Thanh Xuân Trung", "Phường Thanh Xuân Trung", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("4db66fbd-b02d-45e4-99c7-18c54dd79503"), 3, "8", "Phường 8", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("4e09452f-1689-4bec-b333-c92ca681cd2e"), 3, "Phước Tiến", "Phường Phước Tiến", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("4e468f0e-4bdd-47dd-8e1e-7fe866863f0a"), 3, "Hoàng Diệu", "Xã Hoàng Diệu", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("4eeeaaf5-d144-49b0-b083-e063822a7f25"), 3, "Trường Yên", "Xã Trường Yên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("4f11c824-bde8-4f0b-9033-44a2b663d6f1"), 3, "5", "Phường 5", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("4f52dd0c-d923-4a31-8df6-ab9e764e5163"), 3, "Phú Nam An", "Xã Phú Nam An", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("4f7c0b39-13fc-4406-a651-54710799d0a5"), 3, "Ba Ngòi", "Phường Ba Ngòi", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("4ff039bc-0dd3-4212-9a77-bfbd9de56263"), 3, "Đồng Nhân", "Phường Đồng Nhân", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), 2, "10", "Quận 10", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("502aea61-af9a-4551-baaf-794309bafc06"), 3, "Vật Lại", "Xã Vật Lại", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("502f54a6-42b8-4da9-b7c7-a8ad62bdb90a"), 3, "Thượng Thanh", "Phường Thượng Thanh", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("50fe2e78-fc5d-4ce8-b6d7-466e6a1fae14"), 3, "Định Công", "Phường Định Công", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("5141e6a5-2c05-48c7-a0d1-c940e9ad886c"), 3, "1", "Phường 1", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), 2, "Ba Đình", "Quận Hà Nội", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("5192c4c3-deae-4273-836b-19041c734938"), 3, "Diên Tân", "Xã Diên Tân", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("5223beb2-7344-4d6d-a0e0-8e9f17d0cb7b"), 3, "North Carolina", "Phường North Carolina", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("5307be83-3895-4e5e-aadd-f08e1cfdaf54"), 3, "12", "Phường 12", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("5311256f-f2fa-4164-b45d-40689c9f9010"), 3, "Cam Phú", "Phường Cam Phú", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("533f8efb-5c71-4e61-844b-14fb41a7cef3"), 3, "Ngọc Khánh", "Phường Ngọc Khánh", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("556e864b-f567-45c9-b61f-b8dcc5436e65"), 3, "Phường 4", "Phường 4", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("55de3259-6859-4c99-a2fd-ec625b4095b4"), 3, "Thanh Bình", "Xã Thanh Bình", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("561b1d5a-a959-4e92-93f9-31ab5f43d486"), 3, "Chương Dương", "Phường Chương Dương", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("566f4290-ece3-419d-ae12-d72cee2b9397"), 3, "Lý Thái Tổ", "Phường Lý Thái Tổ", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("579160c3-c20f-4778-aa01-bdde8182c08e"), 3, "Cẩm Lĩnh", "Xã Cẩm Lĩnh", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), 2, "Hà Tĩnh", "TP.Hà Tĩnh", new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), null, "Quận/Huyện" },
                    { new Guid("57e91b66-593b-4b3b-9439-e588077481d6"), 3, "Khánh Phú", "Xã Khánh Phú", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("58733a32-e93a-40d5-ad86-c3dcd06c7e41"), 3, "Yên Sở", "Phường Yên Sở", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("58a59cc9-42a0-41b7-891a-324d0196516b"), 3, "10", "Phường 10", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("5a039651-0bd3-4b1a-9b7d-c37f589cbabc"), 3, "Phạm Ngũ Lão", "Phường Phạm Ngũ Lão", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("5a334fd9-63f2-4907-9a97-51111a546993"), 3, "Bến Nghé", "Phường Bến Nghé", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("5a41cb6a-842f-4da4-91a9-9e0fc7da1a1b"), 3, "Đồng Lạc", "Xã Đồng Lạc", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("5a441189-eeeb-4552-b8da-af36d57bcd0b"), 3, "Nam Đồng", "Phường Nam Đồng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("5b0b610b-c06c-401d-8a41-f4d4ee5da51d"), 3, "Vạn Thắng", "Xã Vạn Thắng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("5b121134-1897-44f2-8c77-8385371fdd1b"), 3, "Bình Trưng Tây", "Phường Bình Trưng Tây", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("5b92093e-3256-4a7e-b039-4ceb3d18aece"), 3, "Khương Trung", "Phường Khương Trung", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("5c028291-360d-4f3f-8977-fcf8a6c31b2d"), 3, "3", "Phường 3", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("5c02e1e9-0d7f-4990-895d-120a56e4b132"), 3, "An Lợi Đông", "Phường An Lợi Đông", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("5cb287b0-30d3-449a-b019-397e69146000"), 3, "Láng Thượng", "Phường Láng Thượng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("5d818fe9-7986-4b16-9ab8-af9128129f74"), 3, "Bình Cát Lái", "Phường Bình Cát Lái", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("5da2db12-c96c-4f78-bb3b-4614a4d39c59"), 3, "Linh Xuân", "Phường Linh Xuân", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("5dc655e7-e71b-4c95-b31f-bdf8f08ecb93"), 3, "Nam Phương Tiến", "Xã Nam Phương Tiến", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("5de91691-73eb-454e-890f-1d845599123d"), 3, "Phạm Tân Định", "Phường Tân Định", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("5e38201b-1fa2-4af7-a325-d7e249e6870a"), 3, "Hòa Hải", "Phường Hòa Hải", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("5eef75f9-2c88-48d4-8c45-53a0173a0182"), 3, "Phúc Đồng", "Phường Phúc Đồng", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("5fa7a5e3-bd3e-459d-85c5-44a284e5247e"), 3, "4", "Phường 4", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("5fda2b01-d66d-45e1-a806-104e99d4b0cb"), 3, "Hạ Mỗ", "Xã Hạ Mỗ", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("603fb33c-9ade-4c4d-8e2b-e4a11ee95498"), 3, "La Khê", "Phường La Khê", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("60835618-9b2d-4b09-ab3f-e8920c80da2f"), 3, "Diên Toàn", "Xã Diên Toàn", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("609f72e2-855a-4b8f-87bb-93aa359034ac"), 3, "10", "Phường 10", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), 2, "Diên Khánh", "Huyện Diên Khánh", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("611c2154-e188-49c9-bb83-351b55a3be4e"), 3, "Phương Mai", "Phường Phương Mai", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("623329bb-b219-4270-a0f3-38d626daf9c9"), 3, "9", "Phường 9", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("6249a5ab-a309-46c2-912e-8e918f53aab7"), 3, "Giang Biên", "Phường Giang Biên", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("62631651-e360-4458-8bee-440506e29b22"), 3, "Thạch Linh", "Phường Thạch Linh", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("6287f878-e041-49f0-a84d-9b59812f2629"), 3, "Hương Vinh", "Phường Hương Vinh", new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), null, "Phường/Xã" },
                    { new Guid("629d5730-a6a6-4749-a70b-002960dc4f8f"), 3, "Nhật Tân", "Phường Nhật Tân", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("62b6c461-5646-4ecc-a0ef-afab093e38ae"), 3, "Phường 18", "Phường 18", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("62dc2367-4461-4b0e-ac5e-6cb0c56d3b9b"), 3, "Phường 1", "Phường 1", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("6300f414-a51a-4f99-b07d-882646e38ffe"), 3, "Quỳnh Mai", "Phường Quỳnh Mai", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("63627c5a-10aa-49fc-a1f9-a0c793cbbfb0"), 3, "Đức Thắng", "Phường Đức Thắng", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), 2, "Bắc Từ Liêm", "Quận Bắc Từ Liêm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("64724112-4ddd-4c68-a877-3d8a1f791c66"), 3, "Phường 13", "Phường 13", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("649c8807-f8bd-4212-b017-44dfbca59b78"), 3, "Dương Nội", "Phường Dương Nội", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("653cbf30-df4a-44c8-a2c3-6bf97e7f8689"), 3, "Kim Chung", "Xã Kim Chung", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("65982593-11e2-4e3d-a3af-1f0ac24da5c8"), 3, "7", "Phường 7", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("65c7042e-6c29-4235-99bc-95f383f64445"), 3, "Kim Giang", "Phường Kim Giang", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("66477a69-c185-4f0c-a1a8-66000bdef7ef"), 3, "Phường 3", "Phường 3", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("674c6c9f-899c-412d-a7d4-5f486f1d84ff"), 3, "13", "Phường 13", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("67fb98c5-5220-4f60-a01d-89cc0b6338c5"), 3, "13", "Phường 13", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("686e13cc-9c1c-449e-81a4-78a76fc9d1b7"), 3, "Lam Điền", "Xã Lam Điền", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("689db8ff-3fb0-4c97-a4a8-3c797233bae8"), 3, "Láng Hạ", "Phường Láng Hạ", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("68a4c706-28a8-4864-962c-ed8280e5648c"), 3, "Chúc Sơn", "Thị Trấn Chúc Sơn", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("68c3e54b-e5ca-43d9-a30a-df5f593024a4"), 3, "4", "Phường 4", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("68c7a1a1-d28d-48b7-83e2-d2d82255b894"), 3, "Phường 1", "Phường 1", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("697f169a-9282-4335-a5b7-c5e0a499ca97"), 3, "Nguyễn Trung Trực", "Phường Nguyễn Trung Trực", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("69b36f64-c5fd-4d81-938b-0e87f3f9674f"), 3, "Nguyễn Trãi", "Phường Nguyễn Trãi", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("6ac977c5-ed82-4119-b371-b7837a0f0819"), 3, "Phường 11", "Phường 11", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("6af9c1d9-8228-412c-a47f-0f0cebb1681e"), 3, "Trung Phụng", "Phường Trung Phụng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("6ba48e49-dbe6-4308-a696-7be8d08ea2de"), 3, "Hiệp Bình Chánh", "Phường Hiệp Bình Chánh", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("6bd9285b-aba8-4611-8762-4075e90522b0"), 3, "Quốc Tử Giám", "Phường Quốc Tử Giám", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("6bdd9128-d8bb-442b-8295-deb46136930b"), 3, "Nghĩa Đô", "Phường Nghĩa Đô", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("6cf81dc6-5351-4275-89ef-0b7d1188cdaa"), 3, "Thành Công", "Phường Thành Công", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("6d2efd6c-2e77-4736-bfbf-df8a42e69d59"), 3, "1", "Phường 1", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("6d887d93-3db6-45f0-a0f9-6602688131df"), 3, "Vĩnh Phước", "Phường Vĩnh Phước", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), 2, "Khánh Vĩnh", "Huyện Khánh Vĩnh", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), 2, "Cẩm Lệ", "Quận Cẩm Lệ", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("6eee8d54-b8a0-4bcb-ae7b-e4a01bee3ed7"), 3, "Thanh Nhàn", "Phường Thanh Nhàn", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("6f49d9b6-d2e8-4472-9e2b-aee8ffcfe0ad"), 3, "Tân Chánh Hiệp", "Phường Tân Chánh Hiệp", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("6f69a295-3ade-4fb5-bc56-f13b640a67aa"), 3, "Vĩnh Hải", "Phường Vĩnh Hải", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("70203223-33d8-43e6-8474-82b1ea01aa5f"), 3, "Phú Phương", "Xã Phú Phương", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("703531b0-023b-4557-9a0e-552dd98e6b47"), 3, "Diên Thạnh", "Xã Diên Thạnh", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("709aacff-6c52-437f-8549-3cec82fbb120"), 3, "Phú La", "Phường Phú La", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("713931cf-28af-46df-907e-b2d9c3d1df85"), 3, "Phường 9", "Phường 9", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("716b4b38-03e2-4333-87bc-16b83163f2f0"), 3, "An Hải Bắc", "Phường An Hải Bắc", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("7232d4ad-a6ca-43b5-a973-5c09ba64c9f3"), 3, "Quan Hoa", "Phường Quan Hoa", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("7244807d-a757-462a-b71d-ff752bdcbed4"), 3, "Hòa Cường Bắc", "Phường Hòa Cường Bắc", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("724f1d6b-5348-4f9d-8839-9e8e13bf3a40"), 3, "Hòa Thọ Đông", "Phường Hòa Thọ Đông", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("743a765c-a412-4bb0-8691-6dca876c47f0"), 3, "Điện Biên", "Phường Điện Biên", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("74d42644-87e1-448b-96ec-bcc0619cf51b"), 3, "15", "Phường 15", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("759d9f51-9fb5-4d61-b4a6-7e09e4045924"), 3, "11", "Phường 11", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("75bf9237-593e-4560-b521-29dee442058c"), 3, "Hòa Cường Nam", "Phường Hòa Cường Nam", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("75cdd833-8a5b-4da6-a9da-0ce9ca2839e0"), 3, "Hòa Minh Tây", "Phường Hòa Minh Tây", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("7637ba91-216b-42cf-bc3e-2efca392006d"), 3, "Phúc La", "Phường Phúc La", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("76abb6f0-302a-487f-aed3-cdcc12825c74"), 3, "12", "Phường 12", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("7719266b-eeee-4c3c-bf7e-290cb5891ff6"), 3, "Ohio", "Phường Ohio", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("772127db-1670-4865-aad2-f881f72d5084"), 3, "Thọ Quang", "Phường Thọ Quang", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("7727b43c-1038-42c0-867f-fced734f2873"), 3, "Mễ Tri", "Phường Mễ Tri", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), 2, "Nam Tây Hồ", "Quận Tây Hồ", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("77764712-d6f2-4c23-ae7a-c58058966a21"), 3, "2", "Phường 2", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("782d9358-ed39-4d8f-9ca0-a5a5304bd999"), 3, "Phường 16", "Phường 16", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("78a46955-ab96-41f7-bbe0-4dcfc4d065ba"), 3, "14", "Phường 14", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("7932412e-dea2-4584-8cf0-2a59e6e38dc0"), 3, "Hàng Bài", "Phường Hàng Bài", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("797077d5-00b9-4131-8094-580f38c2b82f"), 3, "Phường 20", "Phường 20", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("7a137a0b-5e3e-48ae-a01e-22a727f96f2e"), 3, "1", "Phường 1", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), 2, "Hai Bà Trưng", "Quận Hai Bà Trưng", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("7c070e6a-e2ff-4437-b36d-7773dda160be"), 3, "Phụng Châu", "Xã Phụng Châu", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("7c0b6bdc-7815-4d8f-93ae-c8f5df5f1ef7"), 3, "Hòa Chính", "Xã Hòa Chính", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("7c3401a7-6167-4ffd-ae3a-165631fac16c"), 3, "Mộ Lao", "Phường Mộ Lao", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("7d0f4cd3-3d45-424c-bcbe-4ff7c5191545"), 3, "Hiệp Bình Chánh", "Phường Hiệp Bình Chánh", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("7d24dc2d-a580-4bf7-baa2-ec700e1d052f"), 3, "Liên Sang", "Xã Liên Sang", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("7defea45-9021-483c-9688-4bd426c835d2"), 3, "Trường Thạnh", "Phường Trường Thạnh", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("7e49bffd-2a76-4582-85ad-9d14ff116146"), 3, "Hòa Minh", "Phường Hòa Minh", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("7ecddc02-2f51-4a5f-9223-fbfb7a3d43f8"), 3, "Vĩnh Trường", "Phường Vĩnh Trường", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("7edd5278-7c33-4486-87d4-29aec266f748"), 3, "Thanh Khê Đông", "Phường Thanh Khê Đông", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("7fa57b39-711f-4c2b-8ba4-b1e3c2eb879d"), 3, "14", "Phường 14", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("7fb3cb10-37fc-4185-95dd-1c006f4f7387"), 3, "Hà Cầu", "Phường Hà Cầu", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("80acf412-aef1-41b1-a4a6-6e601d785692"), 3, "Khuê Mỹ", "Phường Khuê Mỹ", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("810c2ea2-32b2-45dc-874f-840ce5b65b5a"), 3, "Kim Liên", "Phường Kim Liêng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), 2, "Thanh Khê", "Quận Thanh Khê", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("81c1f92a-0c2e-440b-9946-adbd7e330cbb"), 3, "Hải Châu II", "Phường Hải Châu II", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("820dd6a4-85f1-40dd-9f6b-4f32abde926b"), 3, "Thanh Khê Tây", "Phường Thanh Khê Tây", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("821b4aa4-850a-4b0d-b6ce-445c4e2e4961"), 3, "An Hải Đông", "Phường An Hải Đông", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("823fb0eb-ff19-4d08-ac0f-a74762264b6d"), 3, "Phường 5", "Phường 5", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("82618e63-d751-4761-a3fc-812a1bb7feaa"), 3, "Phường 8", "Phường 8", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("8358597a-badb-4d9f-a5e7-bec98dd401fb"), 3, "Phường 14", "Phường 14", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("839043ef-db09-4f4d-9343-642f2bd18e30"), 3, "Đan Phượng", "Xã Đan Phượng", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("83b59815-e38d-49b9-98cc-1b8d449dcf29"), 3, "Vĩnh Phúc", "Phường Vĩnh Phúc", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("85c5ebe7-905d-48a4-84de-3f508ba5776e"), 3, "Hoàng Liệt", "Phường Hoàng Liệt", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("86239d16-364e-483a-9c6d-643e434f44ac"), 3, "Tràng Tiền", "Phường Tràng Tiền", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("86f758c4-8ab5-441e-b38a-23b9debdf3ce"), 3, "Vân Hóa", "Xã Vân Hóa", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), 2, "Chương Mỹ", "Huyện Chương Mỹ", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("882172a5-a4c7-46b0-b113-cec4f530effe"), 3, "Tân Thới Hiệp", "Phường Tân Thới Hiệp", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("88635c88-0587-42e9-8d75-3ddd54278345"), 3, "Cổ Loa", "Xã Cổ Loa", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), 2, "Ngũ Hành Sơn", "Quận Ngũ Hành Sơn", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("89240c3d-aedd-4bd8-8749-bbfb1efc714e"), 3, "15", "Phường 15", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("894fd431-62c1-48c1-8a39-8015c9f933ac"), 3, "Hòa Khánh Bắc", "Phường Hòa Khánh Bắc", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("89730af6-0db1-452f-9cb3-8a434c4612ed"), 3, "5", "Phường 5", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("89946e7a-ce5b-4983-ace0-332ddb37b215"), 3, "Nam Hà", "Phường Nam Hà", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("89e52118-e1d4-4ca6-a686-dfb451b5da66"), 3, "Bạch Đằng", "Phường Bạch Đằng", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("8a61fe5b-c6f7-42b3-a876-4fdc683c55c7"), 3, "Lê Đại Hành", "Phường Lê Đại Hành", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("8a9b40b8-5d8e-438a-8e2c-dc7c2600471c"), 3, "1", "Phường 1", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("8b873f44-94b5-40d7-b22e-61a30947618b"), 3, "13", "Phường 13", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("8ba94c70-fd87-4307-b277-de57923cf0c8"), 3, "Kim Mã", "Phường Kim Mã", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("8c955627-c394-4bf0-9e24-941d126d478c"), 3, "Hiệp Thành", "Phường Hiệp Thành", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("8d7a5a8d-a86c-487b-a1f5-7a2af9a6b1b6"), 3, "Linh Tây", "Phường Linh Tây", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("8d83739a-9580-4e9b-a277-d49f030fa66a"), 3, "An Khê", "Phường An Khê", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("8d8e4fe5-c822-43a8-93cb-c2ce3ae7650b"), 3, "14", "Phường 14", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("8f187153-d781-4d05-8886-f2c5863d115e"), 3, "Tân Chánh Hiệp", "Phường Tân Chánh Hiệp", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("8f1da6cd-6177-4320-8623-5c926dce61c1"), 3, "7", "Phường 7", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("8f84fc40-88f7-4740-8e33-2f08d726efc1"), 3, "Tân Thới Hiệp", "Phường Tân Thới Hiệp", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("8fc0c7c7-c184-430c-b0f9-a335bf0b42ae"), 3, "Linh Xuân", "Phường Linh Xuân", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), 2, "Hoàn Kiếm", "Quận Hoàn Kiếm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("9006c6f3-ba6e-416c-a3e0-4835d8e39994"), 3, "Ngọc Hòa", "Xã Ngọc Hòa", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("900c42d3-1a8a-47af-8047-44d947f6b733"), 3, "Quang Trung", "Phường Quang Trung", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("91374da9-9e79-40ef-a5e7-1af3d8c44e83"), 3, "Châu Sơn", "Xã Châu Sơn", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("92536c6c-4ef9-4767-9f9e-825518aafec3"), 3, "Tản Hồng", "Xã Tản Hồng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("92883ff6-9a2e-4091-b278-70638aaffffb"), 3, "Hàng Bồ", "Phường Hàng Bồ", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("93dacf86-8c23-4a3b-ad77-6f2a0e24f7d0"), 3, "Vĩnh Trung", "Xã Vĩnh Trung", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("95892a83-1167-49c4-a656-2e14deca0ccf"), 3, "Phước Long", "Phường Phước Long", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("962d9ad4-0b1e-4f89-bed1-5af126e9a170"), 3, "Hưng Thịnh", "Phường Hưng Thịnh", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("96a98a69-6acd-4e24-b271-a1567d40744f"), 3, "Giáp Bát", "Phường Giáp Bát", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("96cc54d0-8269-4479-87ab-a97b9a77919d"), 3, "Phú Thượng", "Phường Phú Thượng", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("978d7633-5b2f-4f85-8a56-d713cb9bc958"), 3, "Phước Ninh", "Phường Phước Ninh", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("97b78901-e38c-40a1-b106-38454bbf7f03"), 3, "Tân Hưng Thuận", "Phường Tân Hưng Thuận", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("98843064-6d05-4b76-930d-bb2ec9eab8c5"), 3, "8", "Phường 8", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), 2, "7", "Quận 7", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("9971669d-54c5-4f42-831c-7308bca6f262"), 3, "11", "Phường 11", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("9978610c-fe68-4269-bec8-4cfd5108e164"), 3, "Phước Hải", "Phường Phước Hải", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("99a3e3fc-53c8-4253-9514-0fa5a56dac79"), 3, "8", "Phường 8", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("99bc5269-72a1-4dee-913b-3cd91605d884"), 3, "Cầu Kho", "Phường Cầu Kho", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("9a010321-d332-4dec-a485-e210374b85c3"), 3, "Trần Phú", "Phường Trần Phú", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("9a496498-b482-41c6-aee9-ceedd22a252f"), 3, "Bắc Hồng", "Phường Bắc Hồng", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("9ab831ed-04bd-470d-b046-695e6ca732b5"), 3, "Tiên Phương", "Xã Tiên Phương", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("9b8b5547-0dda-4129-b6d9-e4a824362311"), 3, "Phường 10", "Phường 10", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("9c065032-0df7-4b04-a7fa-c4e452a521b2"), 3, "3", "Phường 3", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("9c478cb6-05aa-49d8-8d17-c7016350b2f0"), 3, "Phường 9", "Phường 9", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("9cb65219-e6c1-47d6-9175-1b01696e11e6"), 3, "Trần Lãm", "Phường Trần Lãm", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), 2, "6", "Quận 6", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("9d364d7f-ae8d-4d10-a632-25a2f644f1b1"), 3, "Chính Gián", "Phường Chính Gián", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("9d45922b-fd1c-48b1-9b2a-221fb6f1e564"), 3, "6", "Phường 6", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("9d559488-b689-4187-8a4f-9f897b190ff1"), 3, "Lĩnh Nam", "Phường Lĩnh Nam", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("9d6a2894-91b8-45c6-8c1b-c3407a43a694"), 3, "Văn Yên", "Phường Văn Yên", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), 2, "2", "Quận 2", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("9e707546-0af5-457e-89dd-ed9cccbdc057"), 3, "Trúc Bạch", "Phường Trúc Bạch", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("9ef7a23e-af33-4c24-9626-e5e55234509d"), 3, "Võng La", "Xã Võng La", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("9f57c1a4-cb63-4d0e-8856-d2bba83c3e89"), 3, "Hòa Khương", "Phường Hòa Khương", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("9f693ef7-6c44-4baf-a89f-14566c9ade05"), 3, "3", "Phường 3", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("a05bb9d0-d7f7-4f7f-9686-bb27ac10c844"), 3, "6", "Phường 6", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("a15d8d3e-36c0-4473-a47d-62ecf5ad14a2"), 3, "Phường 12", "Phường 12", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("a1c172a2-0185-4e5b-8fa4-a75d910b8e20"), 3, "1", "Phường 1", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), 2, "Thái Bình", "Thành Phố Thái Bình", new Guid("d285807c-184c-4505-b39b-f15108486656"), null, "Thành Phố" },
                    { new Guid("a29635de-5dce-47e1-a6ba-88461c6d94a7"), 3, "Phú Cường", "Xã Phú Cường", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("a2fbcb9d-9824-4a16-91ed-2644cd5e1899"), 3, "Cầu Dền", "Phường Cầu Dền", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("a312d5fa-ff7a-450d-a4ab-729e458fd9fe"), 3, "Hòa Thọ Đông", "Phường Hòa Thọ Đông", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("a3724d8b-d395-4886-87d3-916fa9d57e7a"), 3, "Hòa Thọ Đông", "Phường Hòa Thọ Đông", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), 2, "Đống Đa", "Quận Đống Đa", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("a48bb2f4-dcaf-4f38-bcc3-cba123741092"), 3, "Biên Giang", "Phường Biên Giang", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("a4aec663-d78b-49ef-b0f6-16a17a424dec"), 3, "Việt Hưng", "Phường Việt Hưng", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("a4af3804-3c49-40ab-ac66-d58e5feadfa8"), 3, "Phường 10", "Phường 10", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("a4f98785-bfca-4d6a-8cf1-250e6981a6bf"), 3, "Tây Đằng", "Thị Trấn Tây Đằng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("a54b2774-1151-4157-b3af-50cc655c1854"), 3, "Linh Tây", "Phường Linh Tây", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("a70db2b6-650c-4253-94f1-41ab1ab7f9f2"), 3, "Ngã Tư Sở", "Phường Ngã Tư Sở", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), 2, "Cam Ranh", "TP.Cam Ranh", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("a8648477-f9b0-4d8a-ae93-03f64e845f8a"), 3, "Ô Chợ Dừa", "Phường Ô Chợ Dừa", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("a875edb0-caeb-43b6-b525-3ee5d6345117"), 3, "6", "Phường 6", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("a8863bab-a3b9-4113-b878-5b9005f55cb6"), 3, "Phú Khánh", "Phường Phú Khánh", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("a9c7608c-8eca-4f6c-a5dd-31e88d39fefa"), 3, "15", "Phường 15", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("aa06f1ef-4a51-4f77-bcdc-d8745f9b5c7f"), 3, "Cam Lợi", "Phường Cam Lợi", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("aa1d9158-ba95-4622-a9fb-c9c0859eefbf"), 3, "Phường 8", "Phường 8", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("aa61e3f3-d95f-4ad6-8f61-385db1fe7443"), 3, "5", "Phường 5", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("aa6a90e6-1476-4462-aa8c-28fced955c0b"), 3, "Phường 2", "Phường 2", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), 2, "4", "Quận 4", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), 1, "Hà Nội", "TP. Hà Nội", null, null, "Tỉnh/Thành" },
                    { new Guid("ab113ca8-8407-43c4-8d3a-da18d8847318"), 3, "An Hải Tây", "Phường An Hải Tây", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("ab6a326b-1613-4f78-aef5-75d808148017"), 3, "Phường 12", "Phường 12", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("abafe729-897f-4c71-a61b-bb62704b92a8"), 3, "3", "Phường 3", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("abf05a7a-3d66-471a-9916-eefffdd4acc5"), 3, "17", "Phường 17", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("ac4b7955-f961-40e6-b453-d7e8fa0a9d83"), 3, "Xuân Phương", "Phường Xuân Phương", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("acd130df-2455-4500-b999-17a08feded45"), 3, "Thanh Xuân Bắc", "Phường Thanh Xuân Bắc", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("ad20ea87-7b19-4d11-8753-a3f9e15b3c90"), 3, "Phường 3", "Phường 3", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("ad60b673-cd6f-40d5-940f-d99c269d3eae"), 3, "Xuân Tảo", "Phường Xuân Tảo", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("ae352adc-b53f-4e10-9d19-e5083d779725"), 3, "Hòa Phát", "Phường Hòa Phát", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("aea12163-c8a9-42c4-96ad-4c2cae721b91"), 3, "7", "Phường 7", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("afa2216c-2dd5-4458-885c-5d77eee0578d"), 3, "Tam Bình", "Phường Tam Bình", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("b020ee09-0ded-4774-86dc-80c94f4e60f4"), 3, "Thụy Phương", "Phường Thụy Phương", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), 2, "8", "Quận 8", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("b0da05ca-f763-488e-b8c5-768c2f6d0f9f"), 3, "Khánh Đông", "Xã Khánh Đông", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("b16447be-e4cb-4663-968a-afd7e37c33c7"), 3, "Yên Bài", "Xã Yên Bài", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("b188c619-1190-42d6-9a3a-c7b93e2dfb70"), 3, "Trung Hòa", "Phường Trung Hòa", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("b192232c-1639-49db-825a-963f7cb61b95"), 2, "Hà Đông", "Quận Hà Đông", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("b1f487d7-6f37-4856-8f21-77f3e50e9e14"), 3, "7", "Phường 7", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("b2295e0d-7a92-4102-8a7c-9604c9d0f3ad"), 3, "9", "Phường 9", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("b2bfcc70-fe08-4018-a18a-b5b29151def2"), 3, "Trương Định", "Phường Trương Định", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("b3a7a7dd-ebe9-4669-9260-7642048fbdf6"), 3, "Nại Hiên Đông", "Phường Nại Hiên Đông", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("b43c3621-57cf-4e19-8c10-0fe86610c841"), 3, "Vĩnh Hưng", "Phường Vĩnh Hưng", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("b57e453e-b864-4c58-8fbe-697b65b8fde2"), 3, "Thượng Cát", "Phường Thượng Cát", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("b59b3e87-e8a1-44fd-9af2-5c9f2c0dc1a0"), 3, "Tây Tựu", "Phường Tây Tựu", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("b5cacc7a-bea1-4b58-bde0-d839ae39b971"), 3, "Tam Bình", "Phường Tam Bình", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("b5d59239-12b4-4bb6-9000-6ecec8f91f55"), 3, "Thảo Điền", "Phường Thảo Điền", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("b649e1a0-e7e7-4fd2-9f71-9c7dd3b37684"), 3, "Tiền Phong", "Phường Tiền Phong", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("b70943c7-824d-4e97-bf93-3c1b6ecb2de0"), 3, "9", "Phường 9", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("b7686bb7-0556-450b-ba92-e5d3e8dbbfb6"), 3, "6", "Phường 6", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("b79d7a35-721b-49d7-a434-8ed22a0c6e1e"), 3, "Bách Khoa", "Phường Bách Khoa", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("b88d3928-efd2-4d46-a752-e6e7b23b396b"), 3, "Cam Lộc", "Phường Cam Lộc", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("b966424c-504d-4d39-96b1-b22e4ce441c1"), 3, "Trần Phú", "Xã Trần Phú", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("b9ac3d42-7528-4f7e-b0b7-7aaf69cdbe67"), 3, "Mỹ Đình 2", "Phường Mỹ Đình 2", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("b9fed122-ac8c-4dda-be70-c963b9741757"), 3, "Hòa Hiệp Bắc", "Phường Hòa Hiệp Bắc", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("bafd83bc-933c-42ce-aa00-1fa972cd3b4e"), 3, "Diên Hòa", "Xã Diên Hòa", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("bb45de8e-6f71-4e6d-83cd-33cb2585852b"), 3, "Cam Linh", "Phường Cam Linh", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("bb46b503-d5ca-44db-9d5c-435238beaffb"), 3, "Linh Chiểu", "Phường Linh Chiểu", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), 2, "Hoàn Kiếm", "Quận Hoàn Kiếm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("bbe65e3b-ba36-408b-8231-37c30fcee961"), 3, "Nguyễn Thái Bình", "Phường Nguyễn Thái Bình", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("bc317572-66fa-49e3-80cc-0208e7879ecb"), 3, "Dục Tú", "Xã Dục Tú", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), 2, "Hải Châu", "Phường Hải Châu", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("be0df960-037f-4ecf-964e-39c5313f746b"), 3, "Trung Tự", "Phường Trung Tự", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("be73b8fc-e3e9-45b9-b153-b0b589ea384a"), 3, "Phường 6", "Phường 6", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("be90a13d-b1e8-4b88-b782-74ddea324628"), 3, "2", "Phường 2", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("beaf4fff-6446-41f1-b5f7-30f4c6f81bc0"), 3, "Liên Hà", "Xã Liên Hà", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("bf297387-d7d5-4918-8877-5876721145e6"), 3, "Tân Mai", "Phường Tân Mai", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("bf358a64-83ce-427e-b9db-a425cc561aae"), 3, "Phố Huế", "Phường Phố Huế", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("bf74c2c2-9fb4-4eed-b00c-6c2ac40497ab"), 3, "Thụy Khuê", "Phường Thụy Khuê", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("c0562e1c-37ae-49da-9c70-f2045240a20f"), 3, "Tân Hưng Thuận", "Phường Tân Hưng Thuận", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("c076ca6b-d1b8-4550-b67f-f158fad5f00f"), 3, "Linh Đông", "Phường Linh Đông", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("c1920801-20ac-4662-bb42-c8253db0cf03"), 3, "Cổ Đô", "Xã Cổ Đô", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("c1c0627c-8eed-44ca-a1d1-f785d8f0214d"), 3, "Sài Đồng", "Phường Sài Đồng", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("c210ff5b-dcdf-4302-9a8e-91ecf83798bf"), 3, "4", "Phường 4", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("c26935d2-8681-4b8f-a83f-353972e5d9c0"), 3, "Phường 6", "Phường 6", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("c29c03e9-b111-4427-8357-8f80bb7350c1"), 3, "Phương Canh", "Phường Phương Canh", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("c3180f60-b9cb-4492-9ca9-62cac6c33ac0"), 3, "Xuân La", "Phường Xuân La", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("c3b6849a-4693-4cc8-a13f-b44a55b17044"), 3, "Sơn Đà", "Xã Sơn Đà", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("c4a1d252-e08e-4bb0-8df3-3b467e09754c"), 3, "Phú Châu", "Xã Phú Châu", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("c4aa5fa1-8c2d-4420-b799-e33f75407970"), 3, "Hòa Thọ Tây", "Phường Hòa Thọ Tây", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("c505c797-735b-4e43-b31a-7f86307e449e"), 3, "Đồng Thái", "Xã Đồng Thái", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("c59ee52c-e89a-42d7-9bda-0828be0ce241"), 3, "Minh Châu", "Xã Minh Châu", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), 2, "5", "Quận 5", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("c663e4e5-b66d-4fde-aa40-f6a85e17a77c"), 3, "10", "Phường 10", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("c6958e23-4546-421b-b849-4221a401ff9a"), 3, "6", "Phường 6", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("c7f24eda-72a5-4950-93aa-4a3ea9d21fc7"), 3, "Trung Liệt", "Phường Trung Liệt", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("c8219c2c-87db-47e1-90bf-9fde7e83f723"), 3, "Mai Động", "Phường Mai Động", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("c84f37a3-93b1-479a-8ae1-5d0ad36ec9fc"), 3, "Xuân Đỉnh", "Phường Xuân Đỉnh", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("c862a621-df7d-4748-a306-7c6fab0c2349"), 3, "Tiên Phong", "Xã Tiên Phong", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("c86b1ec2-a129-4dec-bddd-a58f0a262d45"), 3, "Cầu Diễn", "Phường Cầu Diễn", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), 2, "Nam Từ Liêm", "Quận Nam Từ Liêm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("c8d71111-d982-4b53-9d2b-d257381b6081"), 3, "Hòa Cường Đông", "Phường Hòa Cường Đông", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("c91f7054-e047-4828-968a-e56cb067f8ab"), 3, "Phường 13", "Phường 13", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("c9cfab4b-074c-4cef-b8d6-4bf1690498e0"), 3, "Đại Nài", "Phường Đại Nài", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("ca1cce71-386a-4ef9-b501-6ceccd013ce9"), 3, "Tốt Động", "Xã Tốt Động", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("ca914c62-4303-4b96-a93a-c196a6b0cd09"), 3, "Đức Thuận", "Phường Đức Thuận", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("cac22691-432d-4f8c-ab45-4b6860903165"), 3, "15", "Phường 15", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("cae93831-3f44-4df8-86d4-894b51f29910"), 3, "17", "Phường 17", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("cc11a988-6684-41e5-812b-e7abc974f1b6"), 3, "Vĩnh Hòa", "Phường Vĩnh Hòa", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("cc17f8ec-a2ea-4902-ace4-0bc1c150b538"), 3, "Thạch Bàn", "Phường Thạch Bàn", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("cc7d9bde-23ad-44bd-becb-cc8b77ce3d97"), 3, "Nguyễn Du", "Phường Nguyễn Du", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("cd9eb7d5-7eac-49c4-bb10-4dc222ec1e5c"), 3, "Lộc Thọ", "Phường Lộc Thọ", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("ce0a8683-01e9-49f1-90fc-60636cebd694"), 3, "Văn Chương", "Phường Văn Chương", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("ce629b43-d1c7-4222-a94c-4d2ff93e40fd"), 3, "Phúc Diễn", "Phường Phúc Diễn", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("cefc95bb-af0b-4bd8-9398-764d9ce7f561"), 3, "Yên Phụ", "Phường Yên Phụ", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("cfb672f7-47ba-4c44-851a-b1aef1021fb5"), 3, "Diên Lạc", "Xã Diên Lạc", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("d006ffb6-c722-4cae-8e02-a854cd555396"), 3, "Kiếm Hưng", "Phường Kiếm Hưng", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), 2, "1", "Quận 1", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("d1c7d8f5-24fa-4ad1-9b2d-e4b00d4a749d"), 3, "Cam Phú Bắc", "Phường Cam Phú Bắc", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), 2, "Sơn Trà", "Quận Sơn Trà", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("d235ecfd-413e-46f7-8717-dfd7b1f6e56f"), 3, "7", "Phường 7", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("d285807c-184c-4505-b39b-f15108486656"), 1, "Thái Bình", "Tỉnh Thái Bình", null, null, "Tỉnh" },
                    { new Guid("d304dae7-59f3-466a-b83e-3a2b5e684eb6"), 3, "8", "Phường 8", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("d3f1c0d8-41de-4b63-b337-e79c0d073e70"), 3, "Phường 12", "Phường 12", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("d3fad483-5871-4002-a0d9-595cf66cf544"), 3, "9", "Phường 9", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("d44a700d-ee55-4e70-98c6-931a3331661c"), 3, "Trần Phú", "Phường Trần Phú", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("d47ebdcf-0158-4f4d-9d4a-8ac792797db7"), 3, "9", "Phường 9", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("d4976353-6080-4586-9a24-8d16b82d22d9"), 3, "Gia Thụy", "Phường Gia Thụy", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("d4b121fa-755b-4fd1-b00f-8685f75338a5"), 3, "7", "Phường 7", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("d5097a2e-749c-4675-ae89-d34884622681"), 3, "Hiệp Bình Phước", "Phường Hiệp Bình Phước", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("d58bb53a-8bb0-4f6a-a177-283cc8a204f1"), 3, "16", "Phường 16", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("d5a6dc43-f155-4490-bf07-638f0ce39720"), 3, "Minh Khai", "Phường Minh Khai", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("d666c83d-e804-4d35-8ed5-36bc9bf570d8"), 3, "4", "Phường 5", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("d67140a4-3546-4f15-8773-12913e026990"), 3, "Văn Quán", "Phường Văn Quán", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("d68cfa51-e70f-4123-b7c3-78c4288f06cb"), 3, "18", "Phường 18", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), 2, "Bắc Cầu Giấy", "Quận Cầu Giấy", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("d760e678-7aca-425a-a625-7bbcfee76d77"), 3, "Khương Mai", "Phường Khương Mai", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("d7cd1ced-94f6-4a07-aa6a-2253160d80ca"), 3, "Nguyễn Du", "Phường Nguyễn Du", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("d7db29e2-e410-4a32-b8c2-1d41c95708ac"), 3, "Phường 3", "Phường 3", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("d8c76079-763f-4c53-87ed-96a255dd3cdc"), 3, "Khương Đình", "Phường Khương Đình", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("d93f9f11-cf46-4fdf-8cc3-c330a025c5f4"), 3, "An Phú Đông", "Phường An Phú Đông", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("d9b2e8c0-06e6-4ab2-9697-44419ef949de"), 3, "Đông Quang", "Xã Đông Quang", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("dc2d9caa-8135-4451-bc4e-fc651504d71d"), 3, "Đồng Phú", "Xã Đồng Phú", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("dccd8487-41c7-42a9-b518-98c2fa5a42c5"), 3, "Phú Đông", "Xã Phú Đông", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("dd3b7dcf-7436-4643-bfaa-e9de2c087180"), 3, "Tòng Bạc", "Xã Tòng Bạc", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("dd9b6dcb-606a-4b0f-b6d7-2ea9699a51e1"), 3, "Thủy Sơn Tiên", "Xã Thủy Sơn Tiên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("de02e622-cc59-4cd9-9d2c-60a053fbcade"), 3, "Hạ Đình", "Phường Hạ Đình", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("e010ca9c-39c8-426d-87cb-3ed2c2de11c0"), 3, "2", "Phường 2", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("e05d69f4-19e2-499b-a0f9-d289ecf602cd"), 3, "Thanh Xuân Nam", "Phường Thanh Xuân Nam", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("e132980d-480a-424a-b6fb-f3741b8d5884"), 3, "Phường 19", "Phường 19", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("e1c8d742-3290-4365-8543-ba284b27d7a2"), 3, "Bình Khánh", "Phường Bình Khánh", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("e2c73a75-81d1-4234-98eb-6c331b589368"), 3, "Văn Miếu", "Phường Văn Miếu", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("e30ec5b7-d437-4cdd-937e-0c257ee1d097"), 3, "15", "Phường 15", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("e384c4f4-7d20-477d-bcb5-f4feea97e98c"), 3, "Ngọc Hà", "Phường Ngọc Hà", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("e3c6e400-5f77-4425-a224-857b631a6f38"), 3, "Đông Sơn", "Xã Đông Sơn", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), 1, "Hồ Chí Minh", "TP.Hồ Chí Minh", null, null, "Tỉnh/Thành" },
                    { new Guid("e49482a8-f71e-4b11-b8a3-4afd13e55350"), 3, "Cầu Ông Lãnh", "Phường Cầu Ông Lãnh", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("e4ad67ea-cad9-45c6-b40c-374162175ae8"), 3, "Bưởi", "Phường Bưởi", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("e4ce2401-fa56-4624-bcdb-20074a808436"), 3, "Phương Liên", "Phường Phương Liên", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("e586bc1b-7d83-41d5-a692-aecc872dd3de"), 3, "Hải Châu  I", "Phường Hải Châu I", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("e5b32ce0-3176-4779-9b00-bf3976a8f0e7"), 3, "Hữu Văn", "Xã Hữu Văn", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("e6c1447d-003d-49bb-9bc6-dbf0225c3b73"), 3, "Tứ Liên", "Phường Tứ Liên", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("e6fca21e-13e0-4dfd-a982-2a3ec92235bc"), 3, "Việt Hùng", "Xã Việt Hùng", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), 2, "12", "Quận 12", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("e7ed7f8d-a2a8-40c6-96a0-7726068d881a"), 3, "Tân Thuận Đông", "Phường Tân Thuận Đông", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("e99d6e09-13ff-43c3-ad4e-bc0858da38ea"), 3, "Xuân Mai", "Thị Trấn Xuân Mai", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("e9ccf559-1ba2-4af9-8927-74a4f246096a"), 3, "11", "Phường 11", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("e9ef5f26-094b-4c10-9986-f09d608aed4d"), 3, "14", "Phường 14", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("ea3caa74-51ff-43b5-8763-be18179b46c8"), 3, "3", "Phường 3", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("ea692ab0-e41a-419a-9513-a5217f777c44"), 3, "Thanh Bình", "Phường Thanh Bình", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("ea72d3b5-d508-42fd-b20f-805ce8ff4a35"), 3, "Thanh Trì", "Phường Thanh Trì", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("eb1a3845-07ba-4177-b3d0-e27e43eaecac"), 3, "Thuần Mỹ", "Xã Thuần Mỹ", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("eb41ebc9-7abb-4cf9-8d9d-72dc14079f8e"), 3, "Hòa Khánh Nam", "Phường Hòa Khánh Nam", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), 2, "Long Biên", "Quận Long Biên", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("ebb7ec1f-8fcf-4256-a0f4-c0c2579a85ce"), 3, "Tân Hưng", "Phường Tân Hưng", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("ebe3fe77-c85a-4931-bfed-bc534973f4e1"), 3, "Tam Thuận", "Phường Tam Thuận", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("ec0b24cc-8972-4d61-9604-5fc82801cc9e"), 3, "Khánh Thượng", "Xã Khánh Thượng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("ec360f2d-ba70-4637-868c-84664df97cf0"), 3, "2", "Phường 2", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("ec92fcc4-4b53-40e8-9e3e-a2504ac63448"), 3, "13", "Phường 13", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("ecf61d92-b1dc-49d5-bee6-1f941399aed9"), 3, "Trường Thọ", "Phường Trường Thọ", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("ed37bebf-d8a2-4f8a-9605-b1e7050f2461"), 3, "Hàng Bông", "Phường Hàng Bông", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("eda187f5-8fc8-41db-9130-642312b9fe22"), 3, "14", "Phường 14", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("eda1dc7c-e3fc-4a5e-accb-d530f36863a1"), 3, "Phước Đồng", "Xã Phước Đồng", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("ee1dc7ae-64f2-44ae-8345-b311480ed4a8"), 3, "Phúc Tân", "Phường Phúc Tân", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("ee36e1a1-c79c-40fd-864d-16b315ba88de"), 3, "Quang Trung", "Phường Quang Trung", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("ef72e8e8-96c7-4c8d-b39a-99d488762852"), 3, "Hoàng Văn Thụ", "Phường Hoàng Văn Thụ", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("f0311850-1757-4ab2-864b-19632aed4d25"), 3, "Hoàng Văn Thụ", "Xã Hoàng Văn Thụ", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("f061b38f-88de-49fe-9572-ec91f9f1e4af"), 3, "Diên Phước", "Xã Diên Phước", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("f066047b-974f-4fa0-aebb-3ec0012438a7"), 3, "Ba Trại", "Xã Ba Trại", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("f106197d-e595-43c4-98cb-595fedcff60a"), 3, "Quảng An", "Phường Quảng An", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("f125f502-b7c3-471c-91b5-e2e6ff3e9c13"), 3, "Hương Trà", "Phường Hương Trà", new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), null, "Phường/Xã" },
                    { new Guid("f13328c0-d23b-4f2c-a518-263759db6c8c"), 3, "Cửa Nam", "Phường Cửa Nam", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("f14e32e1-2b4e-4312-ad67-d0df46fb40bc"), 3, "Vĩnh Thái", "Xã Vĩnh Thái", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("f1837804-67f6-42a8-90b1-812492bf5cc7"), 3, "Giảng Võ", "Phường Giảng Võ", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("f1d405af-49db-4711-9999-f41ac8717565"), 3, "Hưng Long", "Phường Hưng Long", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("f1f2ec19-02f8-4509-8018-3ced88c97354"), 3, "Hàng Bạc", "Phường Hàng Bạc", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("f240cdd8-cc4f-432b-9263-4307a14360d4"), 3, "Nhân Chính", "Phường Nhân Chính", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("f383621e-d221-4e61-9c8f-59b278dbdc93"), 3, "Xuân Canh", "Xã Xuân Canh", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("f3aa648b-ae93-40f5-b5fd-e087b7c6261d"), 3, "An Khánh", "Phường An Khánh", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("f3b58911-74f6-48fe-92f3-f93115d74bec"), 3, "3", "Phường 3", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("f485b796-b3f7-46d0-82ea-23ecec23e325"), 3, "Liễu Giai", "Phường Liễu Giai", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), 2, "Hương Sơn", "Huyện Hương Sơn", new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), null, "Quận/Huyện" },
                    { new Guid("f520a149-8dc9-4543-97fa-ad6be8edd8a4"), 3, "Bồ Đề", "Phường Bồ Đề", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), 1, "Hà Tĩnh", "Tỉnh Hà Tĩnh", null, null, "Tỉnh/Thành" },
                    { new Guid("f6caf0cd-4007-470b-891f-31824094e5fb"), 3, "Thụy An", "Xã Thụy An", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("f6e1d8f1-3546-4c93-8bd4-00e5545e451f"), 3, "Cống Vị", "Phường Cống Vị", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("f71a9459-b99d-4254-907e-d4e94b87863d"), 3, "4", "Phường 4", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("f7d41b0f-ba43-4bfd-9913-1b3efb3440dc"), 3, "Ngọc Thụy", "Phường Ngọc Thụy", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("f7e0cf15-7bd5-4b85-9a18-18688db312f4"), 3, "Nam Dương", "Phường Nam Dương", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("f7e5e5cf-c0e4-4ffb-a857-23a734e7b2b5"), 3, "Mai Dịch", "Phường Mai Dịch", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("f7ff64aa-b8a6-46e0-ac67-884e4bdea793"), 3, "Kỳ Bá", "Phường Kỳ Bá", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("f85135e8-0cfb-4cba-a869-4056671bbc7e"), 3, "Đống Mác", "Phường Đống Mác", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), 2, "Linh Chiếu", "Quận Linh Chiếu", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("f8f76817-260a-411c-a9d9-d68f98dd8957"), 3, "12", "Phường 12", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("f9027707-80ad-4df7-9add-19ad15d37ec0"), 3, "2", "Phường 2", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("fab75a34-0087-4b82-a0c8-211cecdecc37"), 3, "An Phú", "Phường An Phú", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("fafb6141-dbd5-4d9a-bf9c-b36338de67ba"), 3, "Phường 6", "Phường 6", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("fb8c5b20-19c1-4449-bb02-1ec3f805cf54"), 3, "Cổ Huế 2", "Phường Cổ Huế 2", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("fbe037ef-da91-45f7-bcea-d766694534d1"), 3, "Đội Cấn", "Phường Đội Cấn", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("fca15119-1930-41f8-a574-5b54b0cca930"), 3, "Phường 14", "Phường 14", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("fcaf1e65-a5c5-4e00-917c-2cd0c95a1cd4"), 3, "12", "Phường 12", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("fce7e336-7c3c-4e79-8592-f79a2fd38007"), 3, "Hiệp Bình Phước", "Phường Hiệp Bình Phước", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("fd12e083-bbe2-4767-b2e8-600bc576f0b5"), 3, "Tương Mai", "Phường Tương Mai", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("fd3b3e1a-42c7-4c7c-91a9-91066b02c2ed"), 3, "Hòa Quý", "Phường Hòa Quý", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("fdcb4f78-17ca-48f7-b772-6569d6eb3599"), 3, "Cự Khối", "Phường Cự Khối", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("fe1b81ea-676c-42a3-869b-1ba9dd33112f"), 3, "Phú Đô", "Phường Phú Đô", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("ff0315d3-7f14-4d74-81b4-84d340aae8a8"), 3, "Cam Phú Nam", "Phường Cam Phú Nam", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("ff94a394-c0dd-463b-9df7-bc623cd83e95"), 3, "Tam Phú", "Phường Tam Phú", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, "Paypal" },
                    { 2, "Cash on deliveryy" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AccountModelId", "Alias", "Author", "Contents", "CreateDate", "IsHot", "IsNewFeed", "MetaDesc", "MetaKey", "Published", "Tags", "Thumbnail", "Title", "View" },
                values: new object[,]
                {
                    { new Guid("00a02b12-859e-40f9-af95-a98259d82e13"), null, "tattered-cover-bookstore-files-for-bankruptcy", "Jim Milliot", "Tattered Cover Book Store, one of the country’s largest and best-known independent bookstores, filed for reorganization under Chapter 11 Subchapter V in the U.S. Bankruptcy Court for the District of Colorado yesterday. According to the Denver Post, documents filed in the bankruptcy court show Tattered Cover was more than $660,000 in the red between January and September. The business owes more than $1 million to publishers, as well as more than $375,000 to Colorado's Office of the State Auditor for abandoned gift cards.\r\n\r\nThe Subchapter V portion of Chapter 11 was enacted by Congress in 2020 to provide a streamlined process for small companies to reorganize. If the financing is approved, Tattered Cover will have access of up to $1 million in debtor-in-possession financing, provided by a new company formed by current company board members and investors that include Leslie Rainbolt and Margie Gart. The new funding, the announcement said, “will be used to obtain much-needed additional inventory in time for the critical 2023 holiday consumer buying season, fulfill customer orders, upgrade technology, and to maintain operations and staff compensation during the restructuring process.”\r\n\r\nVarious companies that supply books to Tattered Cover said that they will need to time to get a better understanding of the store's new financing before deciding on how to continue to work with the store in the future. The store has been on credit hold with a number of publishers.\r\n\r\nThe current owners, Bended Page LLC, acquired Tattered Cover in 2020 and, after an initial period of expansion, found business slowing, due in part to the pandemic. The bookstore also endured some management changes when Kwame Spearman, one of the lead investors who was named CEO, stepped down from that position in April after deciding to run for mayor of Denver. He subsequently withdrew from that race, and is now running for the Denver school board.\r\n\r\nIn July, Brad Dempsey, a lawyer specializing in finance and business restructuring, was named interim CEO. “Our objective is to put Tattered Cover on a smaller, more modern and financially sustainable platform that will ensure our ability to serve Colorado readers for many more decades,” Dempsey said in a statement. “Restructuring for long-term viability requires managers to make very difficult business decisions that affect people and business partners, and we intend to do what we can to minimize these impacts.”\r\n\r\nDempsey was referring to a host of changes that are in the process of being implemented. Among them are closing three of its seven stores: the locations in Denver’s McGregor Square, Westminster, and Colorado Springs. Those stores are expected to be closed by early November, at which time inventory and technology from the three will be transferred to the store’s four other locations.\r\n\r\nThe store closures will result in cutting “at least” 27 staff positions out of Tattered Cover’s current 103 positions, though the company said that some employees may fill temporary seasonal positions at the remaining stores during the holiday season. Tattered Cover’s Denver International Airport locations will continue operating, as part of a licensing agreement with Hudson Bookstores.\r\n\r\nIn addition to Dempsey, the company’s restructuring will be led by its senior management team: CFO Margie Keenan, newly named COO Jeremy Patlen (formerly v-p of buying), and Alexis Miles, v-p of human resources.\r\n\r\nThe company said that all customer gift cards will be honored, and orders will continue to be fulfilled, while all loyalty programs will also continue as usual. Events currently scheduled for this October and November at closing locations will be rescheduled, if possible, to take place at the store’s remaining locations, with all event changes to be posted on the bookseller's website.\r\n\r\nThe original Tattered Cover was opened in 1971 by Stephen Cogil and purchased by Joyce Meskis in 1974. Meskis sold it to Len Vlahos and Kristen Gilligan in 2015, who sold it to the current owners. The store is considered among the leading independent bookstores in the country, and has a long history of being at the forefront in the fight for free speech and First Amendment rights.", new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2949), true, true, "Tattered Cover Book Store Files for Bankruptcy", "Tattered Cover Book Store Files for Bankruptcy", true, "Tattered Cover Book Store Files for Bankruptcy", "tattered-cover-bookstore-files-for-bankruptcy.jpg", "Tattered Cover Book Store Files for Bankruptcy", null },
                    { new Guid("04ae815d-a560-415e-9ec6-97153fb1788f"), null, "new-thrillers-about-true-crime", "Liz Scheier", "Amazon Publishing associate publisher Gracie Doyle understands the appeal of amateur sleuthing. “I can’t be the only kid who wanted to be a detective,” she says. “And with all of us home for a couple of years, there’s a Rear Window element. We all love a good mystery.”\r\n\r\nAmong the books on her list is Elle Marr’s The Alone Time (Thomas & Mercer, Mar. 2024), which sees long-buried truths coming to light. Twenty-five years after Fiona and Violet Seng survived the private plane crash that killed their parents and left the girls, then ages 13 and seven, stranded in the Pacific Northwest wilderness for three weeks, a persistent documentarian calls into question their version of the events.\r\n\r\nIn Janice Hallet’s The Mysterious Case of the Alperton Angels (Atria, Jan. 2024), two true crime authors tussle over the career-making untold story of a cultlike group who believed that the child of one of its members was the Antichrist. “There’s a fine line between what’s public safety and what’s invading people’s privacy,” says Atria senior editor Kaitlin Olson. “Amateur detectives can go too far. We’ve seen this play out in real investigations—while intentions are really good, people on social media can get in the way.”\r\n\r\nThe intentions aren’t even necessarily good in Dervla McTiernan’s What Happened to Nina?, in which a character posts videos with conflicting theories of what happened to a missing girl in order to sow confusion. (See PW’s q&a with Dervla McTiernan, “Trial by Internet.”) In Kellye Garrett’s next thriller, the entire internet is on the lookout for a woman who fits the ideal victim profile: a Missing White Woman (Mulholland, Apr. 2024; Garrett discusses the phenomenon in “Social Distortion.”)\r\n\r\nHusband and wife team Nicci Gerrard and Sean French, who’ve written numerous thrillers as Nicci French, probe the ramifications of reopening old wounds in their latest, Has Anyone Seen Charlotte Salter? (Morrow, Mar. 2024). The wife and devoted mother of the title disappears just before her husband’s 50th birthday party; when a neighbor’s body is found soon after, the police conclude that the two were having an affair and died in a murder-suicide. Thirty years later, the neighbor’s son produces a popular podcast about the tragedy, throwing both families into turmoil.\r\n\r\n“We need stories, they explain life to us,” Gerrard says; she and French are former journalists. “But sometimes there isn’t a shape to the mess of life. We read stories of serial killers, and when there’s no evident psychological motivation, it’s like trying to find a fingerhold in smooth rock.”\r\n\r\nAnything for the story\r\n\r\nJournalists are held to a standard the average TikTok creator isn’t, but they, too, can lose sight of the impact their work has on their subjects. Christina Estes draws on more than 20 years of reporting experience for her debut novel, Off the Air (Minotaur, Mar. 2024), in which journalist Jolene Garcia hopes that her investigation of a death at a local radio station will make her career. “She comes up against a line she isn’t sure she should cross,” says Minotaur associate editor Madeline Houpt. “She thinks, ‘Am I going too far?’ But she wants to solve the case.”\r\n\r\nJenny Hollander, director of content strategy at Marie Claire, turns the tables on a fellow journalist in her debut, Everyone Who Can Forgive Me Is Dead (Minotaur, Feb. 2024). Charlie Colbert, a successful magazine editor, witnessed a horrific event at her journalism school nine years earlier. When she learns that one of her former classmates is making a movie about the event, known as the Scarlet Christmas, Charlie worries that the truth will come out. “She doesn’t totally remember what happened,” says St. Martin’s editor Sallie Lotz, who edited the book. “But she knows she lied about it.”\r\n\r\nAlmost Surely Dead by Amina Akhtar (Mindy’s Book Studio, Feb. 2024) tells the story of Dunia, a woman who is attacked on the subway, unravels, and then goes missing. Two obsessed journalists launch a true crime podcast seeking fame from Dunia’s misfortune: they want a Netflix deal, they’re selling merch. “I wanted to dive into trauma as content,” Akhtar says. “There should be a code of ethics for true crime. Something horrible happened to somebody; if the family is willing to talk to you, you’re probably walking the right line. If someone doesn’t want their story told, whose decision is it to tell it? Who owns the story?”\r\n\r\nJason Pinter explores the tension between truth-telling and entertainment-selling in Past Crimes (Severn House, Feb. 2024), set in a near-future where true crime fans can immerse themselves in hyper-realistic simulations of gruesome historical killings; people can pay to search for clues inside Jeffrey Dahmer’s Wisconsin cabin, for instance, or attend Lincoln’s assassination. “In these virtual experiences, the evilness has been taken out,” Pinter says. “All we’re left with is the entertainment.”\r\n\r\nIn Jeffrey B. Burton’s The Dead Years (Severn House, Mar. 2024), a long-dormant serial killer sees a Netflix docudrama based on his crimes, and isn’t happy about his portrayal. “Morbid curiosity is a universal trait,” Burton says. “Every day in some paper somewhere around the world, there’s a story that proves truth is stranger than fiction—‘Holy shit, what did the guy do?’ ”", new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2958), true, true, "New Thrillers About True Crime", "New Thrillers About True Crime", true, "New Thrillers About True Crime", "new-thrillers-about-true-crime.jpg", "New Thrillers About True Crime", null },
                    { new Guid("14026935-30ce-453c-9a13-5995e4d307a6"), null, "jennifer-belle-gets-brave-and-regrets-everything", "David Adams", "Things couldn’t have gone much better for a 28-year-old debut author in 1996. There were blurbs from Jay McInerney (“a funny, sad, nasty little gem of novel”) and Tama Janowitz (“hilariously enthralling”). Madonna optioned the film rights—and wanted to direct. “Best new novelist,” declared Entertainment Weekly. “I think I was in 14 magazines at the same time, on a newsstand on my corner,” Jennifer Belle says via Zoom from her art-cluttered apartment overlooking New York City’s Washington Square Park.\r\n\r\nAnd then there was the dead fish. A bucket of them, to be precise, brought to Belle’s first Greenwich Village apartment by a photographer on assignment. “We spent a whole day shooting,” she recalls, “and somehow in the end, the picture—a full page in New York magazine—is me with a real dead fish on my head. There was a really nice one, where I’m kind of leaned over. Like, I have a headache and I’m holding the fish like a hot compress.” She recreates the pose with her iPhone. “But that’s not the one they used.”\r\n\r\nIf ever there was a debut novelist who didn’t need a prop, it was Belle. Her downtown “it girl” resumé would have been enough to make Chloë Sevigny jealous: the daughter of poet Jill Hoffman, Belle dropped out of high school at 15, lied her way into a job at a Bleecker Street bar, played a young Penny Arcade in the performance artist’s shows at La MaMa theater, and started her novel, Going Down, to have something to read at her mother’s writing workshops. By the time the book came out, she was selling luxury apartments for the Corcoran Group. The one job she’d never had, Belle informed New York’s profile writer, was the occupation Going Down’s 19-year-old protagonist takes up to pay for college: call girl. That is indeed what happens in the summer of 1982 to Swanna Swain. Her parents, like Belle’s, are recently separated. Her mother, like Belle’s, is a Guggenheim-winning poet. Her interests, like Belle’s, would run screaming from the snake-infested woods of Vermont, where her mom’s new boyfriend has a room at an artists’ retreat, and toward the landmarks of 1980s Manhattan: Canal Jeans, O’Neals’ Baloon, Woody Allen.\r\n\r\nThen the novel, which Akashic describes as “a kind of inverse Lolita,” reaches its midway point, and Swanna does something Belle never did. “I never got into an older man’s car and went to his house for two days or three days while his wife was away in England,” she says. “It’s more of a composite of older men I dated, which was not unusual back in 1982 or ’3 or ’4 or ’5, or probably today. I mean, I don’t know anybody who didn’t make out with the bartender at their friend’s bar mitzvah or the limo driver at the prom.”\r\n\r\nIs it wise for a novelist with a history of being confused for her characters to write about a teenage seductress? Maybe not. But Belle, who’s girded herself for her first interview in 12 years with red lipstick and a pair of miniature Barbie doll earrings, is the type of raconteur who can’t resist a good punchline, even when she knows it’ll get in her trouble. “Your editor thought you’d be a good match for a book about pedophilia?” she quips, two minutes into our conversation.\r\n\r\nIn a more reflective moment, Belle says that Swanna “never feels like a victim. I think she probably is a victim because she’s 14 and she’s having an affair with a 37-year-old married man. But she doesn’t feel that way for one minute. She thinks she’s in control and she really thinks she’s in love.”\r\n\r\nThough the parallels to Lolita are clear, a different novel served as the inspiration for Swanna’s story: Charles Portis’s True Grit. Belle, who was given a copy by someone in her writing workshop—she runs four of them out of her apartment and has helped shepherd into print novels by Nicola Harrison and Marilyn Simon Rothstein—says it “looked like nothing I would be interested in whatsoever. It has a gun on the cover. But something about reading this book about a 14-year-old girl who sets out to avenge her father’s murder—and she’s unapologetic and she’s cool and she’s tough—something just went off in my head. That I could tell my story the way I wanted to tell it. But I had to make the book more than just being picked up and going to this artist colony that didn’t allow kids. So, I added stuff.”\r\n\r\nOf course, it’s the stuff Belle added that may land her in hot water. Why take the risk? Partly, she says, because she’s “so unhappy with the state of publishing—the censorship going on all over the place.” Asked for an example, she points to a former member of her workshop, Jeanine Cummins, whose 2020 bestseller American Dirt met with fierce backlash from Latinx writers who accused Cummins and her publisher, Flatiron Books, of exploiting their stories.\r\n\r\n“Basically, every single publishing house wanted this book,” Belle says. “And by the end of her journey, she was canceled. All the publishers should have stood up and said, ‘We wanted this book. We decide who gets to tell what story. Not one person on the internet.’ ”\r\n\r\nBelle notes that when her agent, Sterling Lord Literistic’s Doug Stewart (who also reps Cummins), sent Swanna in Love “around to all the big people, they said, ‘Great writing. We love her. But we don’t have a vision for it.’ That was the word I got. I thought I’d be on Zooms with people, and they’d say, ‘Let’s make her older,’ or, ‘Let’s make him younger.’ But what I found were no Zooms, just this language about ‘vision.’ ”\r\n\r\nBelle counts herself lucky to have landed at Akashic, which she’s admired “from the very beginning” (her friend Arthur Nersesian’s The Fuck-Up was the indie press’s first release, in 1997). And while the crusader in her is ready to defend the idea that “people have the right to write whatever they want,” the novelist in her is mainly just thrilled to have unlocked a story she’s been trying to tell for a long time.\r\n\r\nOriginally planned as a flashback in another novel, Swanna in Love came “pouring out” of Belle during Covid lockdowns, when she spent 14 weeks with her husband and two sons in their Hudson Valley country house. “I had never spent 14 days in that house,” she says. “And what I discovered is, I really don’t like it there. I just hated it so much. Something about connecting with that feeling of powerlessness, of having no control over your environment, like when you’re 14 or 15 or 16, brought this character out of me.”\r\n\r\n“I have spent a decade helping other people get published,” Belle says at another point in the conversation. “And writing also, but not writing what I wanted to write. And then something changed. I got brave. Maybe I’ll change my mind. I’ve regretted everything I’ve ever done in my life, so it wouldn’t surprise me.”", new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2966), true, true, "Jennifer Belle Gets Brave and Regrets Everything", "Jennifer Belle Gets Brave and Regrets Everything", true, "Jennifer Belle Gets Brave and Regrets Everything", "jennifer-belle-gets-brave-and-regrets-everything.jpg", "Jennifer Belle Gets Brave and Regrets Everything", null },
                    { new Guid("64d77717-e322-412a-b341-c194429ebd79"), null, "fans-recharge-the-conmics-industry-at-new-york-comic-con-2023", "Heidi MacDonald", "New York Comic Con held an exhausting but exhilarating annual celebration of comics and pop culture October 12–15 at the Javits Center in New York City. While final attendance count is still pending, estimates are that crowds surpassed last year’s 200,000.\r\n\r\nThe show floor presented a psychedelic mash-up of pop culture, with manga and anime dominating. Massive character balloons of Goku from Dragon Ball and Luffy from One Piece loomed over the throngs, while immersive 3D manga displays from Shueisha and impressive activations from Crunchyroll, Manga Plus, and Bandai drew long lines. The prevalence of manga and anime-inspired costumes amongst cosplayers made clear just how much younger fans are riding the manga wave.\r\n\r\nFor publishers, it was a transitional year. Marvel was the only major comics publisher to invest in a prominent show floor presence, as DC, Dark Horse, and Image mostly sat it out, while IDW set up in Artist Alley on the lower level. But the gap left an opening for upstart exhibitors like Vault and Mad Cave to shine. And other new imprints, partnerships, and brands dotted the show floor.\r\n\r\nThe splashiest announcement was for Ghost Machine, added as an imprint at Image Comics led by veteran writer/producer and former DC Comics executive Geoff Johns. The brand promises a creator-owned line of comics with a shared universe and media development; creators involved include artists Gary Frank and Bryan Hitch and novelist Brad Meltzer. Also from Image, creator Rick Remender (Deadly Class) promoted his new Giant Generator imprint, sporting an international cast of creators including Daniel Acuña, Paul Azaceta, JG Jones, and Bengal. Another new player, Massive Publishing, serves as a publishing partner for various entities, such as collectibles auction app WhatNot and existing music-to-comics label Behemoth.\r\n\r\nThis buzz rose above reports of slower industry sales, discussed across the dedicated professional programming held Thursday. Direct market distributor Lunar kicked things off with a retailer breakfast, where Ghost Machine debuted. Retailer organization ComicsPRO followed with a slate of presentations, including updates on a metadata project that brings together an unprecedented mix of publishers, distributors, and retailers aiming to standardize industry metadata—with an eventual goal of sellthrough sales charts, now unavailable for the direct market.\r\n\r\nICv2’s presentation by Milton Griepp showed graphic novel sales strong and overall sales higher than 2019, but periodical comics sales slipping—even as the book market in general continues to soften following its pandemic highs. Concerns over inflation cutting into discretionary spending were also noted.\r\n\r\nYet the mood at the show was optimistic. Despite the high costs that prevented other publishers from exhibiting, Vault CEO and publisher Damian Wassel noted that Vault’s many readers in the NYC market made it worth their investment. “Attendance was incredible, and our sales were up dramatically over last year,” he said. “It's our best con ever.”\r\n\r\nMad Cave debuted recent licenses with Winx and Gatchaman, setting up their largest booth to date to showcase their expansion. “We got to show off Papercutz for the first time at NYCC [and] all the new things that we're doing, including more creator owned or licensed projects,” said CMO Allison Pond.\r\n\r\nAbrams ComicArts editor-in-chief Charles Kochman was pleased to see major book trade houses—including PRH, MacMillan, HarperCollins—and comics publishers united in one area on main the show floor. “By putting us together, you give people a sense of comparing and contrasting, but also there's a community among publishers,” he said.\r\n\r\nPRH highlighted their many genre imprints, along with new arrivals Ten Speed Graphic and a look-ahead to Inklore, a new imprint publishing manga, manhwa, and webtoons. According to PRH director of brand events Lindsey Elias, “people are super excited about Inklore and want to buy the [not yet released] books now,” adding: “We're able to do sales, marketing, and publicity all in one go.”", new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2956), true, true, "Fans Recharge the Comics Industry at New York Comic Con 2023", "Fans Recharge the Comics Industry at New York Comic Con 2023", true, "Fans Recharge the Comics Industry at New York Comic Con 2023", "fans-recharge-the-conmics-industry-at-new-york-comic-con-2023.jpg", "Fans Recharge the Comics Industry at New York Comic Con 2023", null },
                    { new Guid("ab24c76b-decf-449c-a75b-224ddfd133ab"), null, "salar-abdohs-tehran-is a-city-of-contradictions", "Leigh Haber", "“I also wanted to have a reckoning with the revolution,” he says. “This move was arguably the foundational step of my life. I could have stayed away like so many exiles and lived a strictly America life. Very deliberately I chose not to.”\r\n\r\nMany of the geopolitical issues of the past 40-plus years, Abdoh contends, stem from the Iranian Revolution, which toppled the monarchy, led to the establishment of the Islamic Republic, and changed the balance of power in the Middle East. “As someone who wanted to be an adventurer even more so than I wanted to be a writer,” he says, “I thought, where else but Iran!”\r\n\r\nTehran, the sprawling city of 15 million where much of A Nearby Country Called Love is set, is portrayed as a place of infinite contradictions. Pollution, traffic jams, overflowing garbage, and precarious construction sites are parts of everyday life. Modesty squads patrol the streets, fining or arresting women for “improprieties” such as not wearing hijabs. There is a steady stream of news about women who choose to burn themselves to death rather than continue to be beaten by husbands, fathers, or brothers for perceived acts of defiance.\r\n\r\nAt the same time, Abdoh’s Tehran is a cosmopolitan city brimming with cafés, culture, and well-educated locals who frequent concerts, galleries, and literary readings. There is also a vibrant underground network of gay bars and drag clubs.\r\n\r\nBut no matter the neighborhood or occasion, there are some constants in Tehran. Among them, and reflected in the psyches of Abdoh’s characters, is dread. “While it’s not quite the quotidian oppression outsiders imagine, there is the sense of always being on edge,” he says. “That dread has become innate, part of our very character.” And yet, he adds, “at some point folk figured out that rather than fighting the authorities to keep them out of their lives, they can simply disregard and ignore them, which creates a schizophrenia that you learn to live with, though at a cost to your mental and physical well-being.”\r\n\r\nA Nearby Country Called Love, which PW’s review called “a moving and nuanced study of gender and sexuality in contemporary Iran,” follows Issa as he reluctantly returns to Tehran from New York City and attempts to come to terms with his brother’s death. As the novel opens, Issa and his friend Nasser are on a mission to avenge the suicide-by-burning of a wife whose husband, the pair believe, drove her to that fate. While Nasser, a fireman who moonlights as an appliance salesman, revels in the testosterone-fueled vigilante mission—their second—Issa, a former soldier, knows there is nothing noble about what they have set out to do. He is also reminded of the persecution his late brother Hashem faced in their neighborhood due to his sexual orientation.\r\n\r\nViolence threads throughout the novel, as do Issa’s questions about the nature of masculinity and what is expected of a man living in contemporary Iran.\r\n\r\n“My father was a boxer and a soldier,” Abdoh says. “Machismo was part of the fabric, part of the molecule of everything that I grew up with. But my brother Reza was into theater and the arts. At an early age, he knew he was gay, and my father viewed him with shame. I was always in the middle, being pulled in both directions. I modeled Issa’s brother on my family experience, and on what Reza endured and accomplished before he died of AIDS in 1995.”\r\n\r\nIssa lives above the dojo his father ran until his death. His brother Hashem was a revered queer artist in Tehran’s underground—and their father did everything he could to scare Hashem straight. After enduring bullying and beatings by schoolmates and his father, Hashem learned to be defiant no matter the price. His death devastated Issa and prompted him to learn more about the community of friends, lovers, and artists who embraced his brother.\r\n\r\nIssa starts by reading authors Hashem cherished: Beckett, Auden, Proust, and Rilke. Soon, he’s attending parties and performances with people in his brother’s circle. Boundaries melt away. Eventually, Issa becomes romantically involved with a man. For Issa, though, this is a process of self-discovery—and even a way of honoring his brother.\r\n\r\nReferences to various Western literary works are sprinkled throughout the narrative, as are mentions of Perso-Arabic classics. The latter, Abdoh says, “cast a huge shadow of influence for me because many of those writers and mystics were always after the ultimate questions. Ontology—the branch of metaphysics dealing with the nature of being—was their bread and butter.” The same can be said for Abdoh, whose work probes the nature of belonging, masculinity, and the self.\r\n\r\nAnd while Abdoh set the novel in Iran and many of its plot points are unique to that country, he also wanted to address the global question of “how to be a man in this day and age,” he says, “when the paradigm of who we are supposed to be has shifted and none of us really knows how to behave, to respond.”", new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2963), true, true, "Salar Abdoh's Tehran Is a City of Contradictions", "Salar Abdoh's Tehran Is a City of Contradictions", true, "Salar Abdoh's Tehran Is a City of Contradictions", "Salar-abdohs-tehran-is a-city-of-contradictions.jpg", "Salar Abdoh's Tehran Is a City of Contradictions", null },
                    { new Guid("d6d8ad63-8d20-4f51-98bf-c36334955918"), null, "the-forest-fires-of-greece-wreathe-christy-lefteri's-latest-novel", "Elaine Szewczyk", "Lefteri’s new novel, The Book of Fire, due out in January from Ballantine, addresses climate change as it follows a contemporary Greek family—music teacher Irini; her painter husband, Tasso; and their daughter, Chara—who live in a village in an ancient forest and whose lives are upended when a fire erupts, decimating both forest and village. The villagers blame a developer who started the fire while clearing land to build a hotel, but he isn’t the sole culprit, as prolonged high temperatures created dry conditions that turned the forest into a tinderbox.\r\n\r\n“How do we deal with situations where there’s someone to blame, but there’s also something bigger happening?” Lefteri says. “And how do we deal with that during times of trauma?”\r\n\r\nThe first time Lefteri saw an out-of-control forest fire in Greece was in 2017, when she was working as a volunteer at an Athens refugee center for women and children who’d been displaced during the Syrian Civil War. “I woke up one morning and the sky was filled with smoke,” she recalls. “There was a fire in a nearby town. It haunted me.”\r\n\r\nLefteri decided to write The Book of Fire in 2021, after another, bigger fire on the Greek island of Evia destroyed an ancient forest, killed more than 100 people, and left others homeless and physically scarred. She went to Greece for six weeks, while three months pregnant, to do research for the novel.\r\n\r\nThis included visiting the town of Mati, the site of yet another fatal fire, in 2018, and talking with still-traumatized locals, many of whom rejected the idea that climate change was responsible.\r\n\r\n“Being there was overwhelming,” Lefteri says. “I wanted to leave, which I felt horrible about. Every time I write a book I feel guilt, about being able to go home, a home that hasn’t been destroyed, that isn’t a camp. There’s this thing that happens to me where I become frightened about life. I can be quite robust, but when I’m alone I feel the fragility of life. It gets to me. I find it hard to regain my grounding, but then I remember what other people are dealing with.”\r\n\r\nLefteri is disarmingly open about her personal life and displays a genuine interest in others, which makes her effective as a field researcher who’s willing to be the sympathetic ear. “Christy is one of the most caring and compassionate people I’ve ever met,” says Lefteri’s agent, Marianne Gunn O’Connor. “She has a beautiful personality and a sweet nature. She worries about the world and writes with her heart.”\r\n\r\nBorn in 1980 in London, Lefteri was a sensitive child who enjoyed oil painting and stories. Her father, who’d been an officer in the war in Cyprus in 1974, came to the U.K. with Lefteri’s mother. Lefteri remembers her childhood home as a warm place, but her father, who she says had undiagnosed PTSD, was prone to outbursts. “That was the impact of someone not speaking about their trauma,” Lefteri explains. “I remember thinking as a child, what am I doing wrong? I still carry that. I’m constantly thinking I’m doing something wrong. That’s how unspoken trauma gets passed from one generation to the next.”\r\n\r\nAs she grew older, Lefteri became interested in writing as a way to express trauma. She worked for a time as a psychoanalyst, and in 2010 she earned her PhD in creative writing from Brunel University and wrote her first novel, A Watermelon, a Fish and a Bible, about the war in Cyprus, as part of her thesis project.\r\n\r\n“Writing really gets to my heart,” says Lefteri, whose characters often use art to cope with their troubles. “I think sometimes we have to go into our pain to overcome it.”\r\n\r\nAnne Speyer, Lefteri’s editor, appreciates the author’s ability to make big topics feel accessible. “Christy is wonderful at taking things that you read about in the news and making them personal,” she says. “She also makes you feel deeply about her characters. That’s the key to a great story, and she’s done it with every book.”\r\n\r\nLefteri’s next novel will be about European women’s football and will be set during World War I and in the present as it explores women’s lives across generations. “The book is linked to what I experienced with my daughter’s dad after she was born,” Lefteri says. “I left like I had lost my independence, that everything was put on me. This book will be about women’s dreams, about how far we’ve come, and if we’ve come as far as we think.”\r\n\r\nAs evening sets in, Lefteri hears a voice downstairs and checks the clock. The nanny is about to leave and it’s time to get her daughter. The pair may go for a walk with their dog, Alfie. (An emphatic animal lover, Lefteri is “completely obsessed” with him.)\r\n\r\nShe hopes The Book of Fire will inspire people to pay attention to how humanity treats the planet and every living thing on it. “There’s a grief we feel at the loss of our environment, and we don’t often realize that it causes such sadness,” she says. “If we lose our world, we’re nothing. Perhaps this book can make people pause and feel. When we really feel, it can impact a decision.”\r\n\r\nElaine Szewczyk’s writing has appeared in McSweeney’s and other publications. She’s the author of the novel I’m with Stupid.", new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2961), true, true, "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", true, "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", "the-forest-fires-of-greece-wreathe-christy-lefteri's-latest-novel.jpg", "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", null }
                });

            migrationBuilder.InsertData(
                table: "TransactStatus",
                columns: new[] { "TransactStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Chưa Giao Hàng" },
                    { 2, "Đang Giao Hàng" },
                    { 3, "Đã Giao Hàng" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5B71C14D-AEDB-41E1-A1D9-943FD5D3983C", "9C0AA3D8-C892-4407-9521-3BBFA5B05D0A" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Active", "Alias", "Author", "BestSellers", "BookDescription", "BookName", "CategoryId", "CreateDate", "Discount", "HomeFlag", "MetaDesc", "MetaKey", "OriginalPrice", "Price", "Tags", "Thumbnail", "Title", "UnitsInStock" },
                values: new object[,]
                {
                    { new Guid("1e30ca47-cdf4-46c1-9e94-ed4db807a7b3"), true, "two-minutes-with-the-devil", "Matt Micheli", true, "It’s the summer of 86, and school is out in the little Gulf Coast town of Harbor Bluff. Maximum Overdrive is at the cinema, Rampage is all the rage at the arcade, and the only rule from parents is to be home in time for supper. Things couldn’t be simpler or better . . . until kids begin disappearing while playing a children’s game called Two Minutes with the Devil.", "Two Minutes with the Devil", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2851), 20, false, "Two Minutes with the Devil", "Two Minutes with the Devil", 13f, 8f, "Two Minutes with the Devil", "two-minutes-with-the-devil.png", "Two Minutes with the Devil", 10 },
                    { new Guid("2a7dc0bc-71ca-4cc9-bb1c-e597f352a912"), true, "the-roommate-pact", "Allison Ashley", false, "The proposition is simple: if ER nurse Claire Harper and her roommate, firefighter Graham Scott, are still single by the time they’re forty, they’ll take the proverbial plunge together…as friends with benefits. Maybe it’s the wine, but in the moment, Claire figures the pact is a safe-enough deal, considering she hasn’t had much luck in love and he’s in no rush to settle down. Like, at all. Besides, there’s no way she could ever really fall for Graham and his thrill-seeking ways. Not after what happened to her father…", "The Roommate Pact", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2896), 20, true, "The Roommate Pact", "The Roommate Pact", 20f, 14f, "The Roommate Pact", "the-roommate-pact.png", "The Roommate Pact", 10 },
                    { new Guid("2f3eae4a-82d2-4e21-bee5-f879e904d736"), true, "the-shining", "Stephen King", true, "Jack Torrance's new job at the Overlook Hotel is the perfect chance for a fresh start. As the off-season caretaker at the atmospheric old hotel, he'll have plenty of time to spend reconnecting with his family and working on his writing. But as the harsh winter weather sets in, the idyllic location feels ever more remote...and more sinister. And the only one to notice the strange and terrible forces gathering around the Overlook is Danny Torrance, a uniquely gifted five-year-old.", "The Shining", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2800), 20, true, "The Shining", "The Shining", 14f, 10f, "The Shining", "theshining.png", "The Shining", 10 },
                    { new Guid("39079b94-3649-49da-9f3b-76eede8f155c"), true, "a-guest-in-the-house", "Emily Carroll", true, "In Emily Carroll's haunting adult graphic novel horror story A Guest in the House , a young woman marries a kind dentist only to realize that there’s a dark mystery surrounding his former wife’s death.", "A Guest in the House", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2821), 20, false, "A Guest in the House", "A Guest in the House", 20f, 15f, "A Guest in the House", "aguestinthehouse.png", "A Guest in the House", 10 },
                    { new Guid("3a429ee1-46a0-49fa-ab42-70c8fc45da6a"), true, "lights", "Brenna Thummler", true, "Following Brenna Thummler’s bestselling and critically acclaimed graphic novels Sheets and Delicates, Marjorie, Eliza, and Wendell the ghost are back to uncover the secrets of Wendell’s human life in the third and final heartwarming installment of the Sheets trilogy.", "Lights", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2825), 20, false, "Lights", "Lights", 20f, 20f, "Lights", "lights.png", "Lights", 10 },
                    { new Guid("3a50ed95-ce13-42ff-a36d-62bb542a1980"), true, "in-charm-way", "Lana Harper", false, "A witch struggling to regain what she has lost casts a forbidden spell—only to discover much more than she expected, in this enchanting new rom-com by New York Times bestselling author Lana Harper.", "In Charm's Way", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2903), 20, true, "In Charm's Way", "In Charm's Way", 20f, 14f, "In Charm's Way", "in-charm-way.png", "In Charm's Way", 10 },
                    { new Guid("4ae5a0e1-433c-4c82-9fdc-6122864c5016"), true, "the-handyman-method", "Nick Cutter", false, "When a young family moves into an unfinished development community, cracks begin to emerge in both their new residence and their lives, as a mysterious online DIY instructor delivers dark subliminal suggestions about how to handle any problem around the house. The trials of home improvement, destructive insecurities, and haunted house horror all collide in this thrilling story perfect for fans of Nick Cutter’s bestsellers The Troop and The Deep", "The Handyman Method", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2829), 20, true, "The Handyman Method", "The Handyman Method", 25f, 20f, "The Handyman Method", "thehandymanmethod.png", "The Handyman Method", 10 },
                    { new Guid("4b5982a4-c533-4f9d-bdbd-e415f97fa76f"), true, "things-in-the-basement", "Ben Hatke", true, "From New York Times bestselling author Ben Hatke comes Things in the Basement , a young readers graphic novel about Milo, a young boy who discovers a portal to a secret world in his basement.", "Things in the Basement", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2854), 20, false, "Things in the Basement", "Things in the Basement", 15f, 10f, "Things in the Basement", "things-in-the-basement.png", "Things in the Basement", 10 },
                    { new Guid("4cb38469-14c5-4ab5-a848-d69600d1511c"), true, "billie-blaster-and-the-robot-armu-from-outer-space", "Laini Taylor", false, "An out-of-this-world new middle-grade graphic novel about a genius scientist and her evil nemesis—from New York Times bestselling author Laini Taylor and cartoonist Jim Di Bartolo", "Billie Blaster and the Robot Army from Outer Space", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2857), 20, true, "Billie Blaster and the Robot Army from Outer Space", "Billie Blaster and the Robot Army from Outer Space", 15f, 10f, "Billie Blaster and the Robot Army from Outer Space", "billie-blaster.png", "Billie Blaster and the Robot Army from Outer Space", 10 },
                    { new Guid("50258c27-6e11-41cf-90d1-ee635f1f73e2"), true, "together-we-rot", "Skyla Arndt", true, "A teen girl looking for the truth about her missing mother forms a reluctant alliance with her former best friend...in exchange for hiding him from his cult-leading family.", "Together We Rot", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2893), 20, false, "Together We Rot", "Together We Rot", 20f, 14f, "Together We Rot", "together-we-rot.png", "Together We Rot", 10 },
                    { new Guid("759d1673-85ff-4eba-b1d7-b84c9718ddc6"), true, "witness-stories", "Jamel Brinkley", false, "From a National Book Award finalist, Witness is an elegant, insistent narrative of actions taken and not taken.", "Witness: Stories", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2873), 20, true, "Witness: Stories", "Witness: Stories", 22f, 16f, "Witness: Stories", "stories.png", "Witness: Stories", 10 },
                    { new Guid("8c0b7c3f-dbf5-416b-9fdd-71ecca4ecc22"), true, "who-we-are-now", "Lauryn Chamberlain", true, "Four friends. Fifteen years. Who We Are Now is a story of Sliding Doors moments, those seemingly small choices of early adulthood that determine the course of our lives.", "Who We Are Now", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2876), 20, true, "Who We Are Now", "Who We Are Now", 15f, 12f, "Who We Are Now", "who-we-are-now.png", "Who We Are Now", 10 },
                    { new Guid("9ab6d64a-9580-4933-a8a1-04e49b30c864"), true, "he who drowned the world", "Shelley Parker-Chan", true, "Zhu Yuanzhang, the Radiant King, is riding high after her victory that tore southern China from its Mongol masters. Now she burns with a new desire: to seize the throne and crown herself emperor.", "He Who Drowned the World", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2899), 20, false, "He Who Drowned the World", "He Who Drowned the World", 20f, 14f, "He Who Drowned the World", "he-who-drowned-the-world.png", "He Who Drowned the World", 10 },
                    { new Guid("a3404d09-6e72-4d87-96bc-02dae40fccba"), true, "the-last-girls-standing", "Jennifer Dugan", true, "In this queer YA psychological thriller from the author of Some Girls Do, perfect for fans of One of Us Is Lying and A Good Girl’s Guide to Murder, the sole surviving counselors of a summer camp massacre search to uncover the truth of what happened that fateful night, but what they find out might just get them killed.", "The Last Girls Standing", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2832), 20, false, "The Last Girls Standing", "The Last Girls Standing", 19f, 14f, "The Last Girls Standing", "the-last-girls-standing.png", "The Last Girls Standing", 10 },
                    { new Guid("a63560b3-e970-417c-8310-6d4051c80fa6"), true, "the-peach-seed", "Anita Gail Jones", false, "Fletcher Dukes and Altovise Benson reunite after decades apart― and a mountain of secrets―in this debut exploring the repercussions of a single choice and how an enduring talisman challenges and holds a family together.", "The Peach Seed", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2870), 20, true, "The Peach Seed", "The Peach Seed", 20f, 15f, "The Peach Seed", "the-peach-seed.png", "The Peach Seed", 10 },
                    { new Guid("a9e2f62f-36fa-41fa-87a0-e0dbd8d40161"), true, "the-apology", "Jimin Han", true, "In South Korea, a 105-year-old woman receives a letter. Ten days later, she has been thrust into the afterlife, fighting to head off a curse that will otherwise devastate generations to come.", "The Apology", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2906), 20, false, "The Apology", "The Apology", 20f, 14f, "The Apology", "the-apology.png", "The Apology", 10 },
                    { new Guid("bb702562-ac3e-4b4d-8b0e-bfa30cf5210d"), true, "a-little-like-walking", "Adam Rex", false, "You’ve Reached Sam meets The Good Place in this deeply-felt, surreal and fully illustrated love story about a girl, a boy, a dreamer, and a dream from best-selling and award-winning author Adam Rex.", "A Little Like Waking", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2889), 20, true, "A Little Like Waking", "A Little Like Waking", 20f, 14f, "A Little Like Waking", "a-little-like-waking.png", "A Little Like Waking", 10 },
                    { new Guid("bea5420f-5843-4bc4-8cc4-f7e552b4cadb"), true, "multitude-of-dreams", "Mara Rutherford", true, "Princess Imogen of Goslind has lived a sheltered life for three years at the boarded-up castle—she and the rest of its inhabitants safe from the bloody mori roja plague that’s ravaged the kingdom. But Princess Imogen has a secret, and as King Stuart descends further into madness, it’s at great risk of being revealed. Rations dwindle each day, and unhappy murmurings threaten to crack the facade of the years-long charade being played within the castle walls.", "A Multitude of Dreams", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2838), 20, true, "A Multitude of Dreams", "A Multitude of Dreams", 15f, 10f, "A Multitude of Dreams", "multitude-of-dreams.png", "A Multitude of Dreams", 10 },
                    { new Guid("c47c0f23-c06f-425f-ae1a-6e7787bc83e7"), true, "the-art-of-scandal", "Regina Black", false, "On the night of her husband Matt’s fortieth birthday, Rachel Abbott receives a sexy, explicit text from her husband that she quickly realizes was meant for another woman. Divorce is inevitable, and Rachel is determined not to leave her thirteen-year marriage empty handed. Meanwhile, Matt, a rising star mayor with his eye on the White House, can’t afford a messy split in the middle of his reelection campaign. They strike a deal: Rachel gets one million dollars and their lavish house in the wealthy DC suburb of Oasis Springs, as long as she keeps playing the ideal Black trophy wife until the election.", "The Art of Scandal", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2886), 20, true, "The Art of Scandal", "The Art of Scandal", 20f, 14f, "The Art of Scandal", "the-art-of-scandal.png", "The Art of Scandal", 10 },
                    { new Guid("d232d4e1-bee5-4a1e-9e6f-c98fa473960d"), true, "milk-and-mocha-our-little-happiness", "Melani Sie", false, "An out-of-this-world new middle-grade graphic novel about a genius scientist and her evil nemesis—from New York Times bestselling author Laini Taylor and cartoonist Jim Di Bartolo", "Milk & Mocha: Our Little Happiness", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2863), 20, true, "Milk & Mocha: Our Little Happiness", "Milk & Mocha: Our Little Happiness", 15f, 10f, "Milk & Mocha: Our Little Happiness", "milk-and-mocha.png", "Milk & Mocha: Our Little Happiness", 10 },
                    { new Guid("eb25be16-7e47-47d6-9f60-0c142c277efd"), true, "the-frangitelli-mirror", "G.R. Thomas", true, "Rose Carbonelli sees ghosts. She doesn’t sleep. She watches every corner, studies every shadow, listens to the screams that no one else hears. Rose Carbonelli is terrified.", "The Frangitelli Mirror", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2845), 20, false, "The Frangitelli Mirror", "The Frangitelli Mirror", 19f, 14f, "The Frangitelli Mirror", "the-frangitelli-mirror.png", "The Frangitelli Mirror", 10 },
                    { new Guid("eb68f8b8-96dd-4924-8d21-68e9271336bf"), true, "omen-of-ice", "Jus Accardo", false, "Keltania Tunne has spent her whole life training to become a bodyguard for a Winter Fae. It’s the highest of honors for a druid…only when Tania arrives at the Winter Court for the first time, nothing is what she expected.", "Omen of Ice", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2910), 20, false, "Omen of Ice", "Omen of Ice", 20f, 14f, "Omen of Ice", "omen-of-ice.png", "Omen of Ice", 10 },
                    { new Guid("ff2f2e40-5631-4977-bfc9-67d1ceb31583"), true, "the-exorcist-legacy-50-years-of-fear", "Nat Segaloff", true, "Since 1973, The Exorcist and its progeny have scared and inspired half a century of filmgoers. Now, on the 50th anniversary of the original movie release, this is the definitive, fascinating story of the scariest movie ever madeand its lasting impact as one of the most shocking, influential, and successful adventures in the history of film. Written by Nat Segaloff, an original publicist for the movie and the acclaimed biographer of its director, with a foreword from John Russo, author and cowriter of the seminal horror film Night of the Living Dead.", "The Exorcist Legacy: 50 Years of Fear", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2842), 20, false, "The Exorcist Legacy: 50 Years of Fear", "The Exorcist Legacy: 50 Years of Fear", 19f, 14f, "The Exorcist Legacy: 50 Years of Fear", "the-exorcist-legacy.png", "The Exorcist Legacy: 50 Years of Fear", 10 },
                    { new Guid("ff303221-6ca4-4a50-8da4-80a095d25689"), true, "kiss-the-girl", "Zoraida Córdova", false, "Ariel del Mar is one of the most famous singers in the world. She and her sisters—together, known as the band Siren Seven—have been a pop culture phenomenon since they were kids. On stage, wearing her iconic red wig and sequined costumes, staring out at a sea of fans, is where she shines. Anyone would think she’s the girl who has everything. ", "Kiss the Girl", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 12, 8, 10, 31, 44, 219, DateTimeKind.Local).AddTicks(2866), 20, true, "Kiss the Girl", "Kiss the Girl", 15f, 10f, "Kiss the Girl", "kiss-the-girl.png", "Kiss the Girl", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransactStatusId",
                table: "Orders",
                column: "TransactStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AccountModelId",
                table: "Posts",
                column: "AccountModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TransactStatus");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
