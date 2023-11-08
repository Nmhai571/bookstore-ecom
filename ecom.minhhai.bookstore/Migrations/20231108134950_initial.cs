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
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
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
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    District = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ward = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avarta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Lastlogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
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
                    AccountModelAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Accounts_AccountModelAccountId",
                        column: x => x.AccountModelAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
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
                    { new Guid("00125605-e66a-4c28-98e3-5445075d41e2"), 3, "Phường 18", "Phường 18", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("00808461-f6e4-4add-8ebb-5ffa9dafc022"), 3, "Đông Sơn", "Xã Đông Sơn", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), 1, "Đà Nẵng", "TP.Đà Nẵng", null, null, "Tỉnh/Thành" },
                    { new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), 2, "Bình Thạnh", "Quận Bình Thạnh", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("0195c537-5106-49c9-acd2-e1cbab86473a"), 3, "Trung Mỹ Tây", "Phường Trung Mỹ Tây", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("01fe3099-96a0-4535-bf15-47c5d8a805f5"), 3, "Phường 14", "Phường 14", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("0259a24a-fcea-4b6f-bf98-ac153f9f54c7"), 3, "Tân Hưng Thuận", "Phường Tân Hưng Thuận", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("0297d5c3-56f2-484d-be46-4b66ce32765f"), 3, "Ngã Tư Sở", "Phường Ngã Tư Sở", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("029a741c-0061-42c6-b20e-9cb3c8c333a2"), 3, "Linh Trung", "Phường Linh Trung", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("02b3418c-9fb6-4c02-9547-4ea23ae8bc06"), 3, "Bắc Hồng", "Phường Bắc Hồng", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("02c17990-12a8-45a6-ba41-a3c54fa7dea3"), 3, "Ngọc Hiệp", "Phường Ngọc Hiệp", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("02d49bad-3dde-48ed-b718-5d61bdf2b1c5"), 3, "Kiếm Hưng", "Phường Kiếm Hưng", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("0323b571-45c8-4190-9ae3-f962a109dac1"), 3, "Hoàng Diệu", "Xã Hoàng Diệu", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("032dff64-9562-4654-9764-16ddbcfd2a45"), 3, "Phú Lương", "Phường Phú Lương", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("03ea8fab-b040-41d9-89b8-d4326f299cb2"), 3, "An Hải Đông", "Phường An Hải Đông", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("046e0d96-cb63-4526-ac07-382890a5c2a5"), 3, "Ohio", "Phường Ohio", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("046ee424-c535-4d2d-be01-0371e13425ad"), 3, "Đại Mỗ", "Phường Đại Mỗ", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("04df4088-00c7-469b-b92a-d3cf19996ec4"), 3, "8", "Phường 8", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("059fe31d-bd48-47d3-a807-169b1efa1b10"), 3, "Khánh Phú", "Xã Khánh Phú", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("05c260d3-4e3f-4639-a5ea-8650027ed742"), 3, "Khâm Thiên", "Phường Khâm Thiên", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("06b95bcf-2b57-4cd2-a982-cca38b7e5d91"), 3, "11", "Phường 11", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("06f1521b-1178-41be-95c9-b62c3a410f45"), 3, "Sông Cầu", "Xã Sông Cầu", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("0718b411-7e01-42d4-8d69-84eb8705fdba"), 3, "Văn Nội", "Xã Văn Nội", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("076e422c-f60b-4f74-87f1-0a8bd4c79f01"), 3, "Phường 5", "Phường 5", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("07943baf-0a36-4455-9ac1-c6ad734bb741"), 3, "Nam Phương Tiến", "Xã Nam Phương Tiến", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("07b35e52-aef6-4752-93f5-6838238bb51c"), 3, "Tây Đằng", "Thị Trấn Tây Đằng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("0865e124-1abd-4bb2-a32f-a2ebcea8130f"), 3, "Tân Thuận Đông", "Phường Tân Thuận Đông", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("088ff33b-24f6-45a5-8f93-c56aaa1d4f44"), 3, "12", "Phường 12", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("089ca432-a72b-4182-8b5a-189df28d9643"), 3, "Phường 10", "Phường 10", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("08ac6881-74f3-4171-ad7b-9520d58ca2a5"), 3, "Hàng Trống", "Phường Hàng Trống", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("097c0e09-9213-42fa-a848-51c47b8f59ba"), 3, "Mỹ Lương", "Xã Mỹ Lương", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), 1, "Khánh Hòa", "Tỉnh Khánh Hòa", null, null, "Tỉnh/Thành" },
                    { new Guid("09e46557-e7cb-4708-acc2-f0589232f62c"), 3, "Bình Khánh", "Phường Bình Khánh", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("0a17b331-1073-4912-a23a-2fe1c5da6ef7"), 3, "1", "Phường 1", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("0a2a5fce-3678-40e2-829d-dcf21b438cdf"), 3, "Trường Yên", "Xã Trường Yên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("0a8dba58-53e1-4a68-b238-6cac025ca5bb"), 3, "2", "Phường 2", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("0a9b9edb-aca1-4e0e-852c-1383fdbba4cb"), 3, "Phường 6", "Phường 6", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("0ada53e5-b0ed-4d6b-affd-744181e00269"), 3, "Phường 13", "Phường 13", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("0af4f920-14d1-4367-b14f-03bc52ce1e56"), 3, "Thạnh Lộc", "Phường Thạnh Lộc", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("0b03379e-41e4-41d7-8576-8283d52ad045"), 3, "Nguyễn Thái Bình", "Phường Nguyễn Thái Bình", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("0c5169bc-d2e2-4052-b73c-04ed0e7352e7"), 3, "Phường 8", "Phường 8", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("0c8b60a3-28e2-493a-a528-555abc1aa4ab"), 3, "Phú Phương", "Xã Phú Phương", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("0d0a8284-8a0f-45cf-9485-0e8f99d1a30a"), 3, "6", "Phường 6", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("0d10da15-db33-462f-a67c-ff1a7277374d"), 3, "La Khê", "Phường La Khê", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("0d16fe9c-9df8-4299-b27a-7b6adcbac682"), 3, "4", "Phường 4", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("0d4436b3-ab71-4eaa-8996-5cca1583c2da"), 3, "Phường 5", "Phường 5", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("0d77ff11-7f90-4d3a-8172-c67eac3aebf3"), 3, "Linh Xuân", "Phường Linh Xuân", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("0e3ccf14-b394-4c79-b380-a43e5f8ac8be"), 3, "Hòa Minh", "Phường Hòa Minh", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("0e8c62ac-ceaf-4f85-b2ae-079608cb4ab3"), 3, "Hòa Minh Tây", "Phường Hòa Minh Tây", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("0ee014ad-61f7-414d-bea2-6cf529d0684e"), 3, "Hàng Bông", "Phường Hàng Bông", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("0f07b13c-c89d-44a0-b816-480562621769"), 3, "Thới An", "Phường Thới An", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("0fcff1d1-f37b-49f7-b8e5-3ae977e08887"), 3, "Phú Cường", "Xã Phú Cường", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("10550a58-1aca-4e87-900e-947839d0cc18"), 3, "Đội Cấn", "Phường Đội Cấn", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("1186ab1a-0205-4ebb-bfe6-eab9e8665bf2"), 3, "Thanh Xuân Bắc", "Phường Thanh Xuân Bắc", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("11bf0362-4f3b-4962-9fb7-d3edae23efe5"), 3, "Thạch Linh", "Phường Thạch Linh", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("11c2aa95-a68b-423f-901e-091bb1536fa7"), 3, "Linh Đông", "Phường Linh Đông", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("11cf64f9-cf76-4e00-84b5-f46bee87b5e2"), 3, "Tiền Phong", "Phường Tiền Phong", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("12681b64-29ba-4bf8-b0ce-3f6794df34df"), 3, "8", "Phường 8", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("12b61d4b-8c11-47ce-ae9d-e19bc5c506d4"), 3, "Cổ Huế 2", "Phường Cổ Huế 2", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("14108441-c48d-4467-b5b0-a3ac4f6f4766"), 3, "Đồng Tháp", "Xã Đồng Tháp", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("142b03a5-b701-459e-8546-b8e321883c15"), 3, "Kim Liên", "Phường Kim Liêng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("1437786f-84a0-4fd5-8fc9-1170277d6eb8"), 3, "Dịch Vọng", "Phường Dịch Vọng", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("146f994c-6d85-40c4-962d-e617fd7e981d"), 3, "Tân Thới Hiệp", "Phường Tân Thới Hiệp", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("14fac44d-956d-400a-bf7c-b0eb853fe626"), 3, "Phước Long", "Phường Phước Long", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("157ef1d5-53f1-4c8b-864b-43276107e786"), 3, "Khánh Bình", "Xã Khánh Bình", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), 2, "11", "Quận 11", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("159a2328-27ec-4d7c-94e9-bc987de05666"), 3, "Bến Thành", "Phường Bến Thành", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("15d047bf-c4f4-4387-86a8-f35e6a7ac46d"), 3, "Phúc Xá", "Phường Phúc Xá", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("161789f6-0d18-4587-9ce5-bfc28db87ed5"), 3, "Hòa Thọ Đông", "Phường Hòa Thọ Đông", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("16ff998f-bf86-4a13-8305-73470fea86e3"), 3, "Phú La", "Phường Phú La", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("1717097f-1a7d-4665-9480-90f6221b8d19"), 3, "Cửa Đông", "Phường Cửa Đông", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("174490c8-3d15-456e-8984-67a21046d15e"), 3, "Phan Chu Trinh", "Phường Phan Chu Trinh", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("1773725e-6d00-44c5-89ed-91bb7369e9ad"), 3, "Hòa Quý", "Phường Hòa Quý", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("17e29b2c-074b-49cf-a696-9ff37bfba6dc"), 3, "Hiệp Thành", "Phường Hiệp Thành", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("17fc58bd-d73f-48f1-b8cc-5baf27881345"), 3, "Hiệp Bình Chánh", "Phường Hiệp Bình Chánh", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("1a1e1f51-d656-4426-bfa4-20bef304f35d"), 3, "Phú Thuận", "Phường Phú Thuận", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("1aaaa13b-9245-4388-99f3-aa169edfe2cd"), 3, "Diên Bình", "Xã Diên Bình", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), 2, "Nha Trang", "TP.Nha Trang", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("1ad73869-e4b5-4a7f-9339-8e9f37aa9201"), 3, "6", "Phường 6", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("1af07d4c-25ff-428e-a05a-48403f14c7ad"), 3, "Yên Phụ", "Phường Yên Phụ", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("1b51630b-4147-4a7f-aa63-689a63e7ceff"), 3, "Lý Thái Tổ", "Phường Lý Thái Tổ", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("1ba26895-4f37-4909-8896-a721a5bd0070"), 3, "Bạch Mai", "Phường Bạch Mai", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("1ba4f306-581b-4800-b3a5-a3512b3b540f"), 3, "Hàng Bồ", "Phường Hàng Bồ", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("1c060a98-5bd4-4731-91cb-274857d77c35"), 3, "Tản Hồng", "Xã Tản Hồng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("1c1bd912-6f4f-4cf5-8f04-f3592db14ddf"), 3, "Quan Hoa", "Phường Quan Hoa", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("1cf512f9-561c-4b48-a793-e75b4b84362d"), 3, "Bình Thuận", "Phường Bình Thuận", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), 2, "Thủ Đức", "Quận Thủ Đức", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("1de2b8d2-ae2f-4d21-ab27-fd7568db3d6d"), 3, "Ba Ngòi", "Phường Ba Ngòi", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("1e4864fe-f8ee-4002-98b5-6c4310dbee4c"), 3, "Xuân Tảo", "Phường Xuân Tảo", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("1e9fcf93-1ef7-4eb1-abd2-4895cd677a50"), 3, "15", "Phường 15", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("1f576497-8666-4b36-9cc9-277bf8293004"), 3, "Vĩnh Trung", "Xã Vĩnh Trung", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("1faf2773-44a8-43ad-942d-3d30ed3de6ae"), 3, "Đông Quang", "Xã Đông Quang", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("20a3b0f9-1e0e-48bc-a73a-247018fe006e"), 3, "Dương Nội", "Phường Dương Nội", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("20e798b8-ff01-4fff-9bac-88c31e31f421"), 3, "Kim Chung", "Xã Kim Chung", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("20ef8ce6-8b2f-4ccd-acb8-2009d84c2989"), 3, "Phúc Diễn", "Phường Phúc Diễn", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("20f33da0-b85b-4d32-bc70-d13c7873efd8"), 3, "Trần Phú", "Phường Trần Phú", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), 2, "Đan Phương", "Huyện Đan Phương", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("21f35a4c-7e80-4703-8c43-b2baef308c6b"), 3, "Khương Đình", "Phường Khương Đình", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("222f6784-f6c7-4c3f-b229-33f3eb2092d8"), 3, "Thanh Khê Tây", "Phường Thanh Khê Tây", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("22674540-3129-440b-a4dd-42e3c9b911ed"), 3, "Quảng An", "Phường Quảng An", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("22ea0aee-7955-4f32-98d2-90ce65c24b27"), 3, "Phường 9", "Phường 9", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("23cc25ef-31fb-4c7e-b893-6d037da4c7fc"), 3, "Hàng Mã", "Phường Hàng Mã", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("23db8b6a-0b04-45b1-9854-862d4d4defba"), 3, "Vĩnh Nguyên", "Phường Vĩnh Nguyên", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("241891ad-ede9-43ae-8118-1ef3801aee91"), 3, "Thọ Quang", "Phường Thọ Quang", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), 2, "Hồng Lĩnh", "Thị xã Hồng Lĩnh", new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), null, "Thị xã" },
                    { new Guid("24bd80d4-da41-488c-9a6c-347daad20325"), 3, "Chương Dương", "Phường Chương Dương", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("2568db44-3381-4b9c-a949-c668fd36ea7d"), 3, "15", "Phường 15", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("257d8a36-1920-44f9-b5ab-a88063eb5c00"), 3, "Giáp Bát", "Phường Giáp Bát", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), 2, "Gò Vấp", "Quận Gò Vấp", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("25a20f9f-e8b9-4886-aa09-8015aff9596d"), 3, "Trần Phú", "Phường Trần Phú", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("25a535af-516b-49e6-9f88-ed0720dae98a"), 3, "Võng La", "Xã Võng La", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("26571453-2800-4c55-b735-916e2f3b128b"), 3, "Phường 4", "Phường 4", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("268726cb-4c1d-49da-afaf-dc82a4cc46d8"), 3, "Phường 2", "Phường 2", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("270b14eb-6e18-431c-981a-44a97d785d43"), 3, "Hòa Phát", "Phường Hòa Phát", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("277e0c90-3451-4e83-b944-00694a10a18f"), 3, "Vĩnh Hưng", "Phường Vĩnh Hưng", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("27a3788d-2fd8-43bf-97d0-d39f14a6c0b9"), 3, "Bình Trưng Đông", "Phường Bình Trưng Đông", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("28c39792-139a-48ec-a74f-27f68fb6a0b1"), 3, "Nhật Tân", "Phường Nhật Tân", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("28d4729c-9d62-4404-ade1-cf101b3c88e7"), 3, "Phước Ninh", "Phường Phước Ninh", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("291b42f5-e599-421e-855f-b91c254651c3"), 3, "4", "Phường 4", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), 2, "Thanh Xuân", "Quận Thanh Xuân", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("29e19582-8130-4ce8-a130-dffe79373b42"), 3, "Tốt Động", "Xã Tốt Động", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("2a4195ed-bc1f-489b-bea0-b09ca72209f6"), 3, "Phước Ninh", "Phường Phước Ninh", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("2a561188-46b8-49ba-a458-085c86db9d3b"), 3, "Khánh Thượng", "Xã Khánh Thượng", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("2ae026aa-820b-46ba-9977-4cfdd4cc1c67"), 3, "Ba Trại", "Xã Ba Trại", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("2b4c48fc-a7c9-482f-86f4-08b1c46551ff"), 3, "Trung Tự", "Phường Trung Tự", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("2b7cf31e-456d-4674-827e-0868120da973"), 2, "Đông Anh", "Huyện Đông Anh", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("2bf8f90e-198e-47ff-8c27-10d742c2a531"), 3, "Tòng Bạc", "Xã Tòng Bạc", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("2d5bec9a-c434-4a95-9e90-387b580aa6f2"), 3, "Đống Mác", "Phường Đống Mác", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("2e4e777c-0c44-45c7-bd75-6c7245f7aac2"), 3, "Thạch Bàn", "Phường Thạch Bàn", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("2e579d3f-4580-4358-874d-a3e4b133cfa4"), 3, "Trần Lãm", "Phường Trần Lãm", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("2f510263-f12e-41a6-b96c-542e3044eb36"), 3, "Phạm Ngũ Lão", "Phường Phạm Ngũ Lão", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("2f79c0dd-87db-43dd-b83f-e287e5edf73f"), 3, "7", "Phường 7", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("2fe63650-dae8-4db4-89c0-45e2b8d154bf"), 3, "Quốc Tử Giám", "Phường Quốc Tử Giám", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), 2, "Tân Bình", "Quận Tân Bình", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("316b47be-ea78-4fc1-9c63-3f21611726d1"), 3, "Hiệp Bình Phước", "Phường Hiệp Bình Phước", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("32309ea8-8fdb-4ad1-a6c1-4f978dfa8845"), 3, "Hòa An", "Phường Hòa An", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("32cf6de7-dc67-465b-b80d-cf0e3c1a157f"), 3, "Cự Khối", "Phường Cự Khối", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("3367442c-2a50-43ed-aed9-ac0c18a0ed62"), 3, "Thuần Mỹ", "Xã Thuần Mỹ", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("33b05c57-53a4-4aa4-ad1e-3737a93c9fdb"), 3, "Kim Mã", "Phường Kim Mã", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("3407e388-b3b6-4efa-a5de-a614eb57b820"), 3, "Quỳnh Lôi", "Phường Quỳnh Lôi", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("341f70b6-e17e-4c7c-a29a-14c3183c49be"), 3, "Khuê Trung", "Phường Khuê Trung", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("3425d019-4179-4657-9ac6-4c0f3c094318"), 3, "Linh Tây", "Phường Linh Tây", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("34525c98-f059-4e8b-9bab-1b890ba9ac3e"), 3, "Hà Cầu", "Phường Hà Cầu", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("34ec7f83-6099-443d-a282-e80f21e921d6"), 3, "Phố Huế", "Phường Phố Huế", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("352d2698-65ae-4e0d-93de-6d49297ccf49"), 3, "Phú Lãm", "Phường Phú Lãm", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("3545142b-e018-4e75-a649-bd84bdf4c92c"), 3, "Khương Trung", "Phường Khương Trung", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("354ac591-1633-4ce8-bfa9-c01a94c3331b"), 3, "Cát Linh", "Phường Cát Linh", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("3555cd52-5c71-452b-bda3-5536d20d2d0a"), 3, "Hữu Văn", "Xã Hữu Văn", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("357dab03-102e-43df-836c-ccba9408948e"), 3, "Hòa Xuân", "Phường Hòa Xuân", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("35e2ca72-2b6c-4742-a98e-9e085ba51334"), 3, "Yên Hòa", "Phường Yên Hòa", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("35eeb032-f878-4ffe-9751-6aec954cfcc6"), 3, "15", "Phường 15", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("365f9879-1e01-496e-8c69-7ff741fa0bf6"), 3, "Phương Mai", "Phường Phương Mai", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("36b0ca58-344c-4c53-ba69-f03656158d05"), 3, "Phạm Tân Định", "Phường Tân Định", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("36de6e94-0301-44bf-b0a7-bd99ba0258eb"), 3, "2", "Phường 2", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("374f0bb4-542e-47f4-8a04-64c7f30e9081"), 3, "8", "Phường 8", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("37cf3e22-f7f0-4c0b-ae0f-8794b011d965"), 3, "Phường 10", "Phường 10", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("37d00e6a-2421-4c78-a817-59737dfac191"), 3, "7", "Phường 7", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("37f41b2c-e937-419c-9c6e-caa52f4e8962"), 3, "Phước Đồng", "Xã Phước Đồng", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("38939665-e999-404d-a9bf-3387d29704fa"), 3, "Đông Phương Yên", "Xã Đông Phương Yên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("39614cdd-1ed6-4e34-9eb8-bd6051753038"), 3, "Láng Thượng", "Phường Láng Thượng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("39b52388-fad0-4a15-804a-4a936b9034e1"), 3, "Thanh Bình", "Phường Thanh Bình", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("39e43e3a-0675-4361-8f6c-af91c17c3bbb"), 3, "Phạm Đình Hổ", "Phường Phạm Đình Hổ", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("3a019059-345e-437d-88e8-9dbfb416cb96"), 3, "Hòa Cường Bắc", "Phường Hòa Cường Bắc", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("3a0db5d5-4992-47bf-89ac-af2f767c6d61"), 3, "Bưởi", "Phường Bưởi", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("3ae65955-283c-435c-bcd8-3b3e5057b319"), 3, "An Phú Đông", "Phường An Phú Đông", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("3b321275-b4ba-4d3d-af83-2ce8f1467016"), 3, "Phường 2", "Phường 2", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("3b5bfd64-0b8d-4be3-92a5-2e861fe4eb52"), 3, "Vật Lại", "Xã Vật Lại", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("3c4ce628-9bc2-424b-acf5-95d4ed6c23aa"), 3, "Hòa Chính", "Xã Hòa Chính", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("3d27ef89-6c64-411b-8581-e9b3bcb5efba"), 3, "Minh Châu", "Xã Minh Châu", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("3d425013-eeee-49d7-b452-044f46522784"), 3, "Minh Khai", "Phường Minh Khai", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("3d647b74-265b-4398-90ac-43f2ab798691"), 3, "Mỹ Đa", "Phường Mỹ Đa", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("3f817454-3dc9-4545-8c3f-e13b35c7a793"), 3, "Tăng Nhơn Phú A", "Phường Tăng Nhơn Phú A", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("4044db66-9629-4e2d-bbcc-466836edfc1c"), 3, "3", "Phường 3", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("414cc673-fa1a-4b0d-985f-ad6feacfdcf0"), 3, "Cam Phú Nam", "Phường Cam Phú Nam", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("42bd6b72-9c24-4cce-8a52-f9c6ad09c231"), 3, "Thịnh Liệt", "Phường Thịnh Liệt", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("440d20f3-2069-46b2-8f60-d7183870e585"), 3, "Linh Chiểu", "Phường Linh Chiểu", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("44970672-c79b-4d0d-bae2-f08a85df516e"), 3, "Kim Giang", "Phường Kim Giang", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("44ced185-32aa-45dc-bca6-411af7502dcb"), 3, "Nghĩa Tân", "Phường Nghĩa Tân", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), 2, "Ba Vì", "Huyện Ba Vì", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("4566e87d-cf8a-44ba-a4a1-9d5e7448fc44"), 3, "Liên Hồng", "Xã Liên Hồng", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("459c2f29-1274-496e-b553-bd0bca94db64"), 3, "Bình Trưng Tây", "Phường Bình Trưng Tây", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("47159c03-f040-4963-9f51-d4ce5c479b56"), 3, "Khuê Mỹ", "Phường Khuê Mỹ", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("478c1ffd-9bf7-458b-aec5-032f1fa669c3"), 3, "7", "Phường 7", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("47b8eb50-f7de-45bb-bc31-206b4bd88bb2"), 3, "Nam Hà", "Phường Nam Hà", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("4811e67c-ff5a-4625-8944-2ea2c7a4c5d1"), 3, "Định Công", "Phường Định Công", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("486e42ae-a341-455a-acd8-aa492d93506e"), 3, "Diên Phước", "Xã Diên Phước", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("499ebc16-facd-42c6-8a9d-8c2730575710"), 3, "Trương Định", "Phường Trương Định", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("49a31a33-2137-4e55-9345-1197103b429a"), 2, "3", "Quận 3", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("49cba864-26b2-43f5-9421-01eb6b9aa4aa"), 3, "3", "Phường 3", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("4a549e80-ae6b-45f4-8074-8f274bba33cd"), 3, "Cam Lộc", "Phường Cam Lộc", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("4a875579-4b37-40a4-9667-bed2b15253c4"), 3, "14", "Phường 14", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("4ac1f019-f02d-422b-8f50-6f4ba0fbfe66"), 3, "9", "Phường 9", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("4b2e38c1-03ff-4ea1-b483-aa82754fe84d"), 3, "Cầu Diễn", "Phường Cầu Diễn", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("4b889c41-763a-4dff-99c6-cff78f7c4ed5"), 3, "Tân Thuận Tây", "Phường Tân Thuận Tây", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("4c26f8b4-d3ba-4cfa-9dfd-5e5aa66b7d86"), 3, "Diên Hòa", "Xã Diên Hòa", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("4c9d419b-09be-4a98-8bb1-7622a3bb760d"), 3, "Vĩnh Phước", "Phường Vĩnh Phước", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("4d6ed4eb-504e-44bc-a3ae-ededf2f10d32"), 3, "Thượng Đình", "Phường Thượng Đình", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("4e5f8709-6a4b-4d2b-99fd-0414b845f1eb"), 3, "Hiệp Bình Phước", "Phường Hiệp Bình Phước", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("4eec20ed-b5f7-4951-ba9e-4eba9f6925e1"), 3, "18", "Phường 18", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("4f102037-f554-4f7e-a587-4d28c94a0a14"), 3, "Văn Yên", "Phường Văn Yên", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("4f27234b-f075-4b9d-99c1-f152b9a366dd"), 3, "An Hải Bắc", "Phường An Hải Bắc", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("4f9ad911-b6d5-422c-9325-7e55dede0aa6"), 3, "Ô Chợ Dừa", "Phường Ô Chợ Dừa", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("4ff99a39-2912-48a0-8a08-d8dfa724fb4b"), 3, "Tam Bình", "Phường Tam Bình", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), 2, "10", "Quận 10", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("50417c01-6100-499d-a37c-ac252f8157f1"), 3, "Cẩm Lĩnh", "Xã Cẩm Lĩnh", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("51414eac-fd84-4684-ba21-bb319d4c3926"), 3, "Bách Khoa", "Phường Bách Khoa", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), 2, "Ba Đình", "Quận Hà Nội", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("5190a06b-2aba-4307-b7e2-f639bc5298f6"), 3, "2", "Phường 2", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("526558df-a5f7-43ca-bedf-87277540a316"), 3, "Phường 7", "Phường 7", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("5315128b-94d6-466b-bdee-f5e5aec01e4a"), 3, "Đan Phượng", "Xã Đan Phượng", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("531ccd68-a2f3-4ccb-8899-1caafdd2cdbf"), 3, "An Hải Tây", "Phường An Hải Tây", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("532fdf94-90d4-43f5-bde7-b02d4ef88003"), 3, "Cam Lợi", "Phường Cam Lợi", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("53874568-426f-4297-b7e5-c5c0249d9db3"), 3, "Phúc Đồng", "Phường Phúc Đồng", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("54172e30-a1d0-4246-8c1c-b83176fb87ec"), 3, "5", "Phường 5", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("5490eacf-60b0-4a2e-9ffb-0b9d73d40681"), 3, "Mai Động", "Phường Mai Động", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("54a8161c-753d-4c83-a4f1-69aa3292a301"), 3, "Vĩnh Lương", "Xã Vĩnh Lương", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("55bd4ef1-1a78-4a08-b8fe-30a9d793892b"), 3, "1", "Phường 1", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("55e49963-810d-4835-8c7e-6f9735630a8e"), 3, "Hòa Phú", "Phường Hòa Phú", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("563e945b-49ef-46f0-8b37-e713e01b6b53"), 3, "Phường 3", "Phường 3", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("5673792b-c5ba-4533-8431-35baea395401"), 3, "Hải Châu  I", "Phường Hải Châu I", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("5693e9bd-c867-4643-bed5-7bd8e3638592"), 3, "Tây Mỗ", "Phường Tây Mỗ", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("56e3b437-15e0-4c74-bf2b-1f184624d7a8"), 3, "Bến Nghé", "Phường Bến Nghé", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("57013283-3006-4227-9ae1-deab280c575a"), 3, "Tân Chánh Hiệp", "Phường Tân Chánh Hiệp", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("57409838-5651-420d-9cf5-985ca200e5e9"), 3, "Mỹ Đình 2", "Phường Mỹ Đình 2", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("5751ce84-5f02-4cab-81bf-04baef9c95a5"), 3, "Hòa Khê", "Phường Hòa Khê", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), 2, "Hà Tĩnh", "TP.Hà Tĩnh", new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), null, "Quận/Huyện" },
                    { new Guid("57f417c5-4374-44d4-991a-9ec57f3b586d"), 3, "Phường 13", "Phường 13", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("5819cf23-691e-414e-9e08-7a534460f90e"), 3, "Hồng Hà", "Xã Hồng Hà", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("58e6cf3a-b625-47cd-8c44-d62927280910"), 3, "5", "Phường 5", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("5927db2b-70a6-45bb-b95f-645377a54c7f"), 3, "Hàng Bột", "Phường Hàng Bột", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("596b42d4-0a27-4960-9bd3-80dd8ea619c8"), 3, "Yên Sở", "Phường Yên Sở", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("596f3882-8656-49e1-9093-e7fa8f92cfaa"), 3, "Phường 11", "Phường 11", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("597e0912-451f-422e-ad52-1f8e495786e6"), 3, "Hòa Cường Nam", "Phường Hòa Cường Nam", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("59bcc6cb-deb7-4803-87d5-8f3aa5e82a00"), 3, "Chính Gián", "Phường Chính Gián", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("5a580914-487a-403d-9754-8dc2d639bf85"), 3, "Hòa Phát", "Phường Hòa Phát", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("5a990dbd-6e9a-4357-bca4-f5683f2e1e28"), 3, "Đồng Xuân", "Phường Đồng Xuân", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("5ac842c8-6ffe-4b8a-8188-3aa74cd763a4"), 3, "Điện Biên", "Phường Điện Biên", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("5b36af7c-957f-43d0-9306-e23af60b7a12"), 3, "Lê Hồng Phong", "Phường Lê Hồng Phong", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("5b48c988-8ccb-4482-8250-b185c7ed0fba"), 3, "Bắc Hà", "Phường Bắc Hà", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("5ba4f207-8bc0-498c-af41-c0ffe2e32fe2"), 3, "4", "Phường 4", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("5bf7175a-388e-41d9-9369-a6bcee4a10b9"), 3, "North Carolina", "Phường North Carolina", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("5ccc2a0e-15e5-438c-b0ba-04e28492a133"), 3, "Mân Thái", "Phường Mân Thái", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("5e501ca0-bfa3-46b2-b944-0910c87e18a8"), 3, "Hải Châu II", "Phường Hải Châu II", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("5e7895de-67d0-4d74-8063-e528850686a0"), 3, "Linh Tây", "Phường Linh Tây", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("5e789e38-acca-4e24-b8ef-fd2dc6401ea8"), 3, "14", "Phường 14", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("5eaabe6f-aa75-44e0-a62e-f2ec0edbf754"), 3, "Khương Mai", "Phường Khương Mai", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("5ec0ec2f-bfd5-4e94-992d-e89553333908"), 3, "Quang Trung", "Phường Quang Trung", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("5f96ffb8-682c-4813-993a-09849ba95e72"), 3, "Phường 6", "Phường 6", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("5fef7dd1-f2fe-45fe-bc91-b80c31e06523"), 3, "14", "Phường 14", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("6002f82c-640c-40f7-91bb-86d410fb66e2"), 3, "11", "Phường 11", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("609dc280-a051-4ccd-a515-0cbdd06c0207"), 3, "Tân Kiểng", "Phường Tân Kiểng", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("609eb118-d69c-402e-bd5a-58315008b0f3"), 3, "Thảo Điền", "Phường Thảo Điền", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("60d29f5e-51e8-4bc5-896c-ab1b755d7de4"), 3, "Phường 4", "Phường 4", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), 2, "Diên Khánh", "Huyện Diên Khánh", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("60f3db16-f37f-4989-a89b-85e6cc2b2619"), 3, "Cống Vị", "Phường Cống Vị", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("61064e17-eb54-4d4e-8062-1e693d658088"), 3, "Quảng Bị", "Xã Quảng Bị", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("619ebfe6-2426-49b5-bb0b-083580d2c1d2"), 3, "Long Biên", "Phường Long Biên", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("62e9c59b-ebac-49b2-8853-93851fd3df6f"), 3, "Nhân Chính", "Phường Nhân Chính", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("6349d580-9780-4ebd-8398-192078cb9dd1"), 3, "Vạn Thắng", "Xã Vạn Thắng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("635832df-1266-48e2-91f9-bb3f6e6f8f78"), 3, "Vạn Phúc", "Phường Vạn Phúc", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("6364656b-3992-420b-8937-1688539034dc"), 3, "Xuân Canh", "Xã Xuân Canh", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("642a8bcd-5836-472e-bb4b-2e5174fbda34"), 3, "Phúc Lợi", "Phường Phúc Lợi", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), 2, "Bắc Từ Liêm", "Quận Bắc Từ Liêm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("65643593-4067-442f-9cca-46b852d5bdee"), 3, "Hòa Hiệp Bắc", "Phường Hòa Hiệp Bắc", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("65698e6d-b2b8-401a-a489-3b725d53bc07"), 3, "Phước Hải", "Phường Phước Hải", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("65854c0e-4e9d-4339-8c3b-aa24ac3315e2"), 3, "Mỹ An", "Phường Mỹ An", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("6587591e-a9e7-45a5-845b-675a75b505ee"), 3, "Biên Giang", "Phường Biên Giang", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("65e03af2-d587-49a9-9fa0-557bfcf1be9a"), 3, "Phường 14", "Phường 14", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("674e7a94-327a-4ad4-9391-e3ada5d21ccc"), 3, "Thụy Phương", "Phường Thụy Phương", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("674eae2f-47e1-467e-9aa3-2fa1573a0476"), 3, "Thanh Khê Đông", "Phường Thanh Khê Đông", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("677791fe-1ba3-4414-9c14-3e70b08b4ea7"), 3, "Vĩnh Hòa", "Phường Vĩnh Hòa", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("68119782-4c2a-424b-929d-e854f248fc9b"), 3, "Cầu Kho", "Phường Cầu Kho", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("6872c5fe-425f-46ec-92ec-a5c70a546a32"), 3, "7", "Phường 7", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("688f10dd-813c-4bb5-bf75-7b5daf3f226c"), 3, "Phước Hòa", "Phường Phước Hòa", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("694fa03a-327f-4345-9b9a-bfa6ec0ce7c3"), 3, "Phường 1", "Phường 1", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("69bd1bab-b82c-4f40-9eec-c1f590d6fbdf"), 3, "Vĩnh Trung", "Phường Vĩnh Trung", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("6b5bcc95-dfe7-439c-a513-27e4278faa6a"), 3, "Lê Đại Hành", "Phường Lê Đại Hành", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("6b857e6e-ec85-4448-ae38-02c1407e8e6b"), 3, "Phường 17", "Phường 17", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("6bd6b383-29f0-42e1-97af-6b84478ef0b7"), 3, "Phường 12", "Phường 12", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("6c46855d-7467-41f6-a995-c36adf3ddf52"), 3, "Hạ Mỗ", "Xã Hạ Mỗ", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("6d7c5ee6-fd81-4e1c-960f-1faf40a160c7"), 3, "An Khê", "Phường An Khê", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("6d8f55ab-cfb1-4137-a630-a7aabb9d6467"), 3, "Tản Lĩnh", "Xã Tản Lĩnh", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), 2, "Khánh Vĩnh", "Huyện Khánh Vĩnh", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("6e5ae229-0a90-43d5-812e-9e7e15ff3833"), 3, "Phường 13", "Phường 13", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("6e71fe8d-04f8-47ca-a4fe-f204b8cda62d"), 3, "7", "Phường 7", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), 2, "Cẩm Lệ", "Quận Cẩm Lệ", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("6ef78a1d-274a-4b9a-80b7-d2c0fecd8cb7"), 3, "Mỹ An", "Phường Mỹ An", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("6f61d820-237d-4a5e-aa98-486d36416c69"), 3, "Vĩnh Tuy", "Phường Vĩnh Tuy", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("6f96cb05-c6c4-460f-84df-ffc020d2db95"), 3, "Văn Quán", "Phường Văn Quán", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("6fa5c361-a4b3-44e8-a0f3-4755561fc684"), 3, "Tiên Phong", "Xã Tiên Phong", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("70623e50-bb8a-4309-b665-d09b39ee20ce"), 3, "Cầu Ông Lãnh", "Phường Cầu Ông Lãnh", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("7069bedb-a5d7-41fa-9e40-05a24790ca09"), 3, "Phú Nghĩa", "Xã Phú Nghĩa", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("71331f63-c898-4e31-9aa9-8f5218be9e06"), 3, "Phú Sơn", "Xã Phú Sơn", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("722f7622-7f4e-49be-8af4-3e350a7f2f27"), 3, "Thượng Thanh", "Phường Thượng Thanh", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("726d15ad-1c9b-451a-afa1-07a78bee6e24"), 3, "3", "Phường 3", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("73b85b19-7aea-4d5c-a49f-43d185d56a49"), 3, "Hòa Thọ Đông", "Phường Hòa Thọ Đông", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("74481d96-e578-4748-ad93-1f7713b996a2"), 3, "Cổ Đô", "Xã Cổ Đô", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("750156ff-78ce-402f-a108-1b3fead52e19"), 3, "12", "Phường 12", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("7532b00e-db9c-438e-bf16-c7db4aa10426"), 3, "Hương Xuân", "Phường Hương Xuân", new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), null, "Phường/Xã" },
                    { new Guid("75e55180-a13a-4ff1-9ad0-2a6c1285a212"), 3, "5", "Phường 5", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("763fc00c-9b69-4221-bcdf-25ebe521924d"), 3, "Hợp Đồng", "Xã Hợp Đồng", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("764c8096-f0be-42fb-88c8-e44488e92519"), 3, "10", "Phường 10", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("76e819cc-3017-491b-9929-22345003cc0d"), 3, "Diên Lộc", "Xã Diên Lộc", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), 2, "Nam Tây Hồ", "Quận Tây Hồ", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("77833fa5-9573-45f8-8ffc-3de995a6c708"), 3, "Khánh Thượng", "Xã Khánh Thượng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("779e5010-46e4-4e09-a338-cfc4d7177630"), 3, "Việt Hùng", "Xã Việt Hùng", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("77c7c3db-1e04-4a20-9ae4-15ab7c7a6af1"), 3, "Ngọc Hà", "Phường Ngọc Hà", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("78495406-6376-4ef8-a208-549f278c43b5"), 3, "Hàng Gai", "Phường Hàng Gai", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("78864ab7-173a-4717-b18d-22c2b8e5d04e"), 3, "2", "Phường 2", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("7888b1aa-db5a-4d44-8c38-b8b7cd9bc172"), 3, "1", "Phường 1", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("78f5aab4-339d-4c82-bb37-b74cd905ef9e"), 3, "Hòa Hiệp Nam", "Phường Hòa Hiệp Nam", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("7942a5d5-6522-41b7-970f-da79deb4b571"), 3, "Thanh Khê Đông", "Phường Thanh Khê Đông", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("799f80f8-59c7-435d-93dc-6e2bcb370ba8"), 3, "Bồ Xuyên", "Phường Bồ Xuyên", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("7ad004b9-20e7-4208-8a92-7003ca3bb74f"), 3, "Mỹ Đình 1", "Phường Mỹ Đình 1", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("7bc9cfad-6ba6-453c-9009-fe8b18556786"), 3, "Nam Đồng", "Phường Nam Đồng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), 2, "Hai Bà Trưng", "Quận Hai Bà Trưng", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("7cc78bb4-0f6d-46c2-8b97-02be7dacf1e5"), 3, "Tứ Liên", "Phường Tứ Liên", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("7cfda163-44b5-41d4-a4dc-40b8cfb4e07e"), 3, "13", "Phường 13", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("7dc3e334-538e-4596-9099-5e62cf0f204f"), 3, "Tây Tựu", "Phường Tây Tựu", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("7dcac404-a139-4505-8830-1da7f7703b77"), 3, "Phú Nam An", "Xã Phú Nam An", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("7e682096-21a7-4db2-ba8f-b8832c39cab4"), 3, "Minh Khai", "Phường Minh Khai", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("7e928490-a573-4512-9068-7d04a69ed245"), 3, "13", "Phường 13", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("7e9be274-41e1-4771-9f72-9845e55a1eab"), 3, "5", "Phường 5", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("7f25cf2f-9a42-432a-912c-fd5d03717b62"), 3, "Thuận Phước", "Phường Thuận Phước", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("7f86877b-4930-4e84-a82c-e43c94afb057"), 3, "Lam Điền", "Xã Lam Điền", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("800c4183-c139-4714-8d35-26572700f28b"), 3, "Thổ Quan", "Phường Thổ Quan", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("80433261-8661-47a3-9f76-499af7505d91"), 3, "Thủy Sơn Tiên", "Xã Thủy Sơn Tiên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), 2, "Thanh Khê", "Quận Thanh Khê", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("818541b1-e090-411e-87f4-1c984a84fb87"), 3, "Hòa Khánh Bắc", "Phường Hòa Khánh Bắc", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("8195c072-6e24-4dd5-bc26-4c71f1d9e9eb"), 3, "8", "Phường 8", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("81d42770-0d55-4a7f-8a95-aa0f7a325ce9"), 3, "Trần Hưng Đạo", "Phường Trần Hưng Đạo", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("8298a53c-c6dd-4a8a-bf88-880a639223e8"), 3, "Phúc Tân", "Phường Phúc Tân", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("831f7eb2-5588-4f48-b3ff-ea48f311c54e"), 3, "3", "Phường 3", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("843acde6-345b-4ef7-87c1-0c8f1ee27b07"), 3, "8", "Phường 8", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("861b3364-7887-4b35-b290-ca97d7e2771f"), 3, "2", "Phường 2", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("86dee735-a1fb-4344-9bf5-cc3fda2022b0"), 3, "Việt Hưng", "Phường Việt Hưng", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("86e15591-e028-4562-8248-2fb5b9a1040e"), 3, "Liên Sang", "Xã Liên Sang", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("8718ecb6-5bcb-49f9-a31a-a3e4b24c1693"), 3, "Thanh Xuân Trung", "Phường Thanh Xuân Trung", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), 2, "Chương Mỹ", "Huyện Chương Mỹ", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("87d61836-9639-4515-9c47-2d9bbdd5f9c9"), 3, "Cô Giang", "Phường Cô Giang", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("88029540-f216-4012-b477-1e2baf69ee22"), 3, "1", "Phường 1", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("8881bbd2-028a-46b9-b480-de7e72661eb3"), 3, "5", "Phường 5", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("889a44e4-01dc-4c50-b0dc-bf94722118b9"), 3, "14", "Phường 14", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), 2, "Ngũ Hành Sơn", "Quận Ngũ Hành Sơn", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("895ec750-fb0e-4ae8-94cf-2e6e02685384"), 3, "12", "Phường 12", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("896db9f2-7f7c-4660-8de5-9e0fdd25a6cb"), 3, "Hòa Thọ Tây", "Phường Hòa Thọ Tây", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("89c7b753-818b-4b6c-9b94-eb0d9e1e3654"), 3, "13", "Phường 13", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("8a9778ec-e275-4c79-beff-377ab3bdf839"), 3, "Phường 5", "Phường 5", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("8ac2a41f-bad5-478f-925d-07fc40736157"), 3, "Hàng Buồm", "Phường Hàng Buồm", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("8ba585ea-d4d6-4c96-ac42-480ab29d74f8"), 3, "Quán Thánh", "Phường Quán Thánh", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("8badbcf6-884c-4ae7-bc3a-9e7f1419e972"), 3, "Khánh Đông", "Xã Khánh Đông", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("8c46fb6d-06fb-4af8-a5c1-c33b3c574345"), 3, "Nguyễn Du", "Phường Nguyễn Du", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("8ce49f08-f7a7-46ea-927a-0ebaa8d05b9a"), 3, "Phường 3", "Phường 3", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("8dba14bb-874b-438c-bf26-36cfdefbecba"), 3, "Hòa Khánh Nam", "Phường Hòa Khánh Nam", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("8e75d679-0b24-4795-85dd-94595050624d"), 3, "Nam Dương", "Phường Nam Dương", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("8e93d44b-73e2-40cd-bcf1-8356cf9bd37c"), 3, "Hưng Lộc", "Phường Hưng Lộc", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("8e9624c0-2dad-44ae-a54b-e224606d1613"), 3, "Linh Trung", "Phường Linh Trung", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("8f22c6d5-5ac2-4248-a545-c53170fea00b"), 3, "An Phú", "Phường An Phú", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("8f37fcc3-3f64-4b24-a1f9-79ff2c3e2949"), 3, "Phường 11", "Phường 11", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), 2, "Hoàn Kiếm", "Quận Hoàn Kiếm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("91c7512e-66b6-4b41-ac35-e4d6730beef0"), 3, "Giang Biên", "Phường Giang Biên", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("92ebb386-18ec-464e-986f-30109fa3bf44"), 3, "Cổ Loa", "Xã Cổ Loa", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("94fdcbfc-c880-4645-b208-021e45c9f3ae"), 3, "Bình Thuận", "Phường Bình Thuận", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("9516c90c-1ec4-46db-9fe5-7c4407282f90"), 3, "Liên Trung", "Xã Liên Trung", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("9536193b-d448-483b-b036-573090e3d617"), 3, "Phường 7", "Phường 7", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("955d0d17-924a-4903-a9d7-fca0babe88f7"), 3, "Vân Hóa", "Xã Vân Hóa", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("978d9f03-ad4a-468c-9b9a-e1f31ac2fd46"), 3, "Hương Vinh", "Phường Hương Vinh", new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), null, "Phường/Xã" },
                    { new Guid("983a5941-890e-430b-8cd0-53c1c27f18a6"), 3, "12", "Phường 12", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("98ac4ee7-56ab-4f2e-8319-5c376b56d8a3"), 3, "Tân Quy", "Phường Tân Quy", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("98f9a4d1-8b37-4d28-8d9c-bc95d6746add"), 3, "Cam Linh", "Phường Cam Linh", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), 2, "7", "Quận 7", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("995c323c-8c09-4737-a895-685a854e3568"), 3, "Hàng Đào", "Phường Hàng Đào", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("99ddca5f-d555-48e2-a60c-c76eab78e07d"), 3, "9", "Phường 9", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("9a05acca-f8fd-4125-b993-80989c238f0f"), 3, "8", "Phường 8", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("9b2eda69-c427-4af9-a513-34efee097b51"), 3, "Khánh Hiệp", "Xã Khánh Hiệp", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("9bf764d4-73e4-4264-abd9-71edcbbb2b86"), 3, "Tiên Phương", "Xã Tiên Phương", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("9c8e4fa2-da75-4fb9-a8ee-c134b6912a14"), 3, "Láng Hạ", "Phường Láng Hạ", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("9c916af7-98a5-46aa-b88a-836a3e80300b"), 3, "Phú Khánh", "Phường Phú Khánh", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("9c9b4bd9-5b4e-44e2-9dd7-191f9bbfdff7"), 3, "6", "Phường 6", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), 2, "6", "Quận 6", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("9d92cf35-badd-4a55-a9e8-2904d1bb064a"), 3, "Phường 8", "Phường 8", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), 2, "2", "Quận 2", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("9e98757f-88f0-4c29-b286-94b3b9d4d616"), 3, "Phường 1", "Phường 1", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("9f127cf7-d3d9-486b-8049-aac7ef301d73"), 3, "Tân Chánh Hiệp", "Phường Tân Chánh Hiệp", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("9f13077e-e713-4b9e-8f38-5a50e0635018"), 3, "Dục Tú", "Xã Dục Tú", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("9f87b1ef-5b68-4202-88fb-6f9b9f5b420d"), 3, "Phong Vân", "Xã Phong Vân", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("9f8952aa-d5cf-4763-aa67-203a864ee7dc"), 3, "7", "Phường 7", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("9f8e66d3-b72e-4c95-92a1-b52d7dc5057c"), 3, "Ngọc Hòa", "Xã Ngọc Hòa", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("9fac8763-218a-44a4-92ac-62ad113581f6"), 3, "Hưng Thịnh", "Phường Hưng Thịnh", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("9fe77b76-b285-4d39-85de-e560a906b2a1"), 3, "Ngọc Khánh", "Phường Ngọc Khánh", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("a0308607-c78a-4aad-80ca-851cf37c686b"), 3, "Hòa Thọ Tây", "Phường Hòa Thọ Tây", new Guid("6edb696a-8413-4f93-8e72-bbbe00d0439a"), null, "Phường/Xã" },
                    { new Guid("a083e323-f59f-4c1d-971f-3308c9fe072a"), 3, "Tân Hưng Thuận", "Phường Tân Hưng Thuận", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("a0a5a5c8-67fc-4222-ac6b-76a59a10486a"), 3, "Diên Lạc", "Xã Diên Lạc", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("a0d44ba5-c86b-47f9-8a86-e44c8e6da6cc"), 3, "Phường 8", "Phường 8", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("a15bd042-acea-4986-a549-db5b5e0dc535"), 3, "5", "Phường 5", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), 2, "Thái Bình", "Thành Phố Thái Bình", new Guid("d285807c-184c-4505-b39b-f15108486656"), null, "Thành Phố" },
                    { new Guid("a252d70e-cf02-444c-8a29-6f2c84add045"), 3, "Trung Liệt", "Phường Trung Liệt", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("a26f8b0e-3136-4931-91cb-21ff7f516812"), 3, "Hương Trà", "Phường Hương Trà", new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), null, "Phường/Xã" },
                    { new Guid("a2932d45-d6d1-4734-af8b-f3dc9588351c"), 3, "Phường 19", "Phường 19", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("a2a922ae-9551-4553-ac31-93b759f347c1"), 3, "6", "Phường 6", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("a2af8b82-2ad0-40e5-b54d-4a3ee077fdb1"), 3, "Trung Hòa", "Phường Trung Hòa", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("a2c76e81-4f45-42d3-9908-95f63ab34f6b"), 3, "Chúc Sơn", "Thị Trấn Chúc Sơn", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("a3782866-aa31-4816-a095-d46bb2be62f0"), 3, "Phường 3", "Phường 3", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("a38dcb97-e055-44c0-978d-c449d6306711"), 3, "An Khánh", "Phường An Khánh", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("a410ff99-aa59-4d0f-9c6b-2c67928231e0"), 3, "Sài Đồng", "Phường Sài Đồng", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("a4217ab8-acdd-4a6d-91b6-75747dd2c84d"), 3, "9", "Phường 9", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), 2, "Đống Đa", "Quận Đống Đa", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("a446a56d-cee1-4bec-9609-af5a5191b14e"), 3, "15", "Phường 15", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("a51036ec-201f-4aa9-991b-89c410d39afe"), 3, "10", "Phường 10", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("a52de5b4-61ce-4082-8ec9-ea37e903a3c1"), 3, "Nguyễn Trung Trực", "Phường Nguyễn Trung Trực", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("a5764b50-ede8-47f5-a02c-31c8ebad567d"), 3, "Hưng Long", "Phường Hưng Long", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("a65e908a-373b-4182-bad4-cb08fa080391"), 3, "2", "Phường 2", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("a6c8f92f-4529-44e2-9a29-0fdc906f8d97"), 3, "Xuân Mai", "Thị Trấn Xuân Mai", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("a7010c7d-103d-4a2b-abd5-d51416570a00"), 3, "Chu Minh", "Xã Chu Minh", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), 2, "Cam Ranh", "TP.Cam Ranh", new Guid("09d71da2-6869-48e1-b7fb-418a162bc6ab"), null, "Quận/Huyện" },
                    { new Guid("a8fa2431-fa87-49a8-9b81-d9d9ad3f0bd6"), 3, "Thụy Khuê", "Phường Thụy Khuê", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("a9400fa9-0dfe-4631-91f4-3a1bb0b0140e"), 3, "Thượng Cát", "Phường Thượng Cát", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("a9a2e5fb-2d5a-43c3-837c-fc1e5e1f3f40"), 3, "Tân Hưng", "Phường Tân Hưng", new Guid("9946273b-38fd-41ca-b82b-3b08352f974d"), null, "Phường/Xã" },
                    { new Guid("a9b66a54-9e3f-4f0f-8017-f6748f3dbea7"), 3, "An Lợi Đông", "Phường An Lợi Đông", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("aa57474d-f3d6-4494-b0e9-93b89a320dd2"), 3, "1", "Phường 1", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), 2, "4", "Quận 4", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), 1, "Hà Nội", "TP. Hà Nội", null, null, "Tỉnh/Thành" },
                    { new Guid("ab18380c-06cb-4403-a190-78f9b153f611"), 3, "14", "Phường 14", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("ab1abc98-030a-4dba-89f1-3f91c8b07861"), 3, "Bắc Hồng", "Xã Bắc Hồng", new Guid("2b7cf31e-456d-4674-827e-0868120da973"), null, "Phường/Xã" },
                    { new Guid("ababf1a2-c8b0-4d33-abb1-e191398b2e36"), 3, "Tam Thuận", "Phường Tam Thuận", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" },
                    { new Guid("abf5ac26-1a04-4806-91df-d6c0778d72c0"), 3, "Thanh Bình", "Xã Thanh Bình", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("ac55c8f7-4a9c-4106-b531-513d495eacbe"), 3, "Vĩnh Phúc", "Phường Vĩnh Phúc", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("acbaa267-4e31-4dbb-b11c-2c483d6eb4db"), 3, "11", "Phường 11", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("adcd5726-849f-405b-a753-d1cead2beb67"), 3, "Khương Thượng", "Phường Khương Thượng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("af6d1d54-cb81-43bf-9476-6e11bf3c1259"), 3, "Yên Bài", "Xã Yên Bài", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("b02f0950-06f7-4a22-91b0-152f8fbda65e"), 3, "Phước Tiến", "Phường Phước Tiến", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("b05a6669-7128-47fd-ad4e-6b9f319539bf"), 3, "16", "Phường 16", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), 2, "8", "Quận 8", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("b192232c-1639-49db-825a-963f7cb61b95"), 2, "Hà Đông", "Quận Hà Đông", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("b1976a41-7320-4e92-b34e-20839035b897"), 3, "Vĩnh Trường", "Phường Vĩnh Trường", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("b243fb6a-8466-46d3-b7e3-4f858eb2b871"), 3, "Phường 1", "Phường 1", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("b2a8b08d-44f6-442f-b99e-10de05b936b7"), 3, "Tăng Nhơn Phú B", "Phường Tăng Nhơn Phú B", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("b39b6506-56be-436e-ae1a-9ecc363d45a0"), 3, "3", "Phường 3", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("b3baaf07-b270-40e2-8144-7135a84f9680"), 3, "Dịch Vọng Hậu", "Phường Dịch Vọng Hậu", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("b3cb663b-ae28-46d4-b98a-f0dc680beb0c"), 3, "11", "Phường 11", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("b43b519e-2f04-4844-b78d-d776f3892436"), 3, "4", "Phường 5", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("b4600c53-dffe-46af-8abc-5716ee58e487"), 3, "Phú Đô", "Phường Phú Đô", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("b4bea9bf-4ad5-4269-af89-93574d99cc1b"), 3, "Đồng Phú", "Xã Đồng Phú", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("b4cdee55-5047-49d8-abd3-e582c98ae70e"), 3, "10", "Phường 10", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("b4deb114-1c20-42ee-8bb9-f5a31bda32b1"), 3, "Tân Mai", "Phường Tân Mai", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("b4e26190-4ee2-4c84-920e-7ae0cab53b34"), 3, "Đại Kim", "Phường Đại Kim", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("b4e94178-f9ca-47c0-a35f-0a27c0ad8c08"), 3, "Đồng Tâm", "Phường Đồng Tâm", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("b512d05d-1676-4643-a43c-ee5a95cfc90c"), 3, "Phương Liên", "Phường Phương Liên", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("b5b613e2-0158-465e-b8f4-161897b6a015"), 3, "9", "Phường 9", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("b6600457-6909-4515-9dfa-d96342959aaf"), 3, "11", "Phường 11", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("b7839608-952b-4696-92d2-021c92e6934d"), 3, "Phước Mỹ", "Phường Phước Mỹ", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("b8024f3e-f3b5-46b6-bcf1-812e28f2eadc"), 3, "Đại Yên", "Xã Đại Yên", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("b8a5322a-68a2-468d-8f80-ea45a3487113"), 3, "Trung Phụng", "Phường Trung Phụng", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("b95c4877-3f41-4d83-9c91-b6b67d5a5b12"), 3, "Văn Chương", "Phường Văn Chương", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("ba750bfc-4f22-4e62-bc6d-95c754aef193"), 3, "Văn Miếu", "Phường Văn Miếu", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), 2, "Hoàn Kiếm", "Quận Hoàn Kiếm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("bc0ab0bb-d6e1-45ca-84cf-32394c423d14"), 3, "Trần Hưng Đạo", "Phường Trần Hưng Đạo", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("bcda7b37-fd7e-4a8b-a14e-71a2a02f90d7"), 3, "Đồng Nhân", "Phường Đồng Nhân", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("bcdbedb3-5646-492b-b62a-6cb822053b9d"), 3, "13", "Phường 13", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("bcf7c3fc-b86f-44ac-b83f-1796a06a3fbf"), 3, "Hồng Phong", "Xã Hồng Phong", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("bd165912-10fd-44ab-ada8-e3d589f4fedd"), 3, "9", "Phường 9", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("bd17f294-fb49-4e30-be20-a50f4e7c944b"), 3, "Lĩnh Nam", "Phường Lĩnh Nam", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("bd2e1b15-df31-442f-9a58-9b58964dbc79"), 3, "Vĩnh Thái", "Xã Vĩnh Thái", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("bdbb0e8a-76b0-42ab-98ad-7eaab4eb94fe"), 3, "Lộc Thọ", "Phường Lộc Thọ", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), 2, "Hải Châu", "Phường Hải Châu", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("be1815da-aaf8-44eb-a9b1-48bf23a57f6d"), 3, "Cầu Dền", "Phường Cầu Dền", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("bea6eadc-246b-4e64-973c-56cae4d8d3cc"), 3, "Cam Phú", "Phường Cam Phú", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("bf00fa31-c824-4d46-8012-7fa268dce926"), 3, "Bình Cát Lái", "Phường Bình Cát Lái", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("bf171d7c-871d-467f-839a-3486b370f7a3"), 3, "Diên Thạnh", "Xã Diên Thạnh", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("bffaa83a-d34c-42de-8f69-f14a83482c96"), 3, "Đồng Mai", "Phường Đồng Mai", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("c1f6cc3a-da1f-4aa2-bb1b-1d8f9e7cfd6d"), 3, "Hòa Thọ Đông", "Phường Hòa Thọ Đông", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("c2087f05-d9ad-442d-9b49-e185fe76a65f"), 3, "Trúc Bạch", "Phường Trúc Bạch", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("c231863b-1030-49cf-bedb-a6105bf231ba"), 3, "Tân Tiến", "Xã Tân Tiến", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("c2dc2de7-0b66-4d63-ab9a-d27dedfe64b3"), 3, "4", "Phường 4", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("c2ed8898-5f5e-4497-a5cd-749390d3a16d"), 3, "Diên An", "Xã Diên An", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("c3f1377b-c6f8-47d3-b8a9-99ddd1c258b5"), 3, "Hàng Bạc", "Phường Hàng Bạc", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("c60f0158-698f-42f1-b9f7-f3a9b4b25264"), 3, "Thanh Lương", "Phường Thanh Lương", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), 2, "5", "Quận 5", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("c63eb5bf-c162-41d3-b276-b02771146329"), 3, "Diên Tân", "Xã Diên Tân", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("c7167e27-e37e-4bed-88a4-815ef5615726"), 3, "Thạnh Mỹ Lợi", "Phường Thạnh Mỹ Lợi", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("c725d7a6-1bb7-4e28-a7b5-06d1d6eac11b"), 3, "Liên Hà", "Xã Liên Hà", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("c7499f30-a474-4e63-9a29-d2e002ac1dc8"), 3, "Đức Thắng", "Phường Đức Thắng", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("c796b671-9779-47f2-b00e-e2a439303b18"), 3, "Mai Dịch", "Phường Mai Dịch", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("c7a4f9f4-6ebc-4c14-939a-1dbb686abf43"), 3, "Phương Liệt", "Phường Phương Liệt", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("c8240ae7-453f-4bdd-8d86-46271afb2fea"), 3, "Cổ Huế 1", "Phường Cổ Huế 1", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("c879cd50-ea6c-4357-86fe-068826aa53be"), 3, "Đông Hưng Thuận", "Phường Đông Hưng Thuận", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), 2, "Nam Từ Liêm", "Quận Nam Từ Liêm", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("c894263f-a0dc-4118-aad6-12d945f0592a"), 3, "Yết Kiêu", "Phường Yết Kiêu", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("c8a2c575-2b06-4981-897f-e52f47026b16"), 3, "Mộ Lao", "Phường Mộ Lao", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("c90141d2-4e45-4149-b042-4bd36c183141"), 3, "Thủ Thiêm", "Phường Thủ Thiêm", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("c94707a8-f6d2-43e1-b2a2-69ea695c552b"), 3, "10", "Phường 10", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("c9d33d5c-7611-407c-9df5-98912272e7a7"), 3, "Hòa Cường Đông", "Phường Hòa Cường Đông", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("c9e1c3f1-c244-4900-82e5-9609e14e48bd"), 3, "1", "Phường 1", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("c9fa67f5-2c4c-4916-a143-6775c40d7664"), 3, "Kỳ Bá", "Phường Kỳ Bá", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("ca6717fa-1d62-4fa1-8585-17ebe982a53c"), 3, "Phường 16", "Phường 16", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("cac94e29-e1c3-4a76-a182-2cfcce9b2412"), 3, "Thành Công", "Phường Thành Công", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("cae5af1b-9871-4c51-a0ca-855ebd0e0baa"), 3, "Thụy An", "Xã Thụy An", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("cbab4840-de50-479c-9a6a-88971668b7f4"), 3, "Thọ Trung", "Xã Thọ Trung", new Guid("214b982c-8805-4897-8e86-9e7d6c644eb5"), null, "Phường/Xã" },
                    { new Guid("ccf6c44e-7bc7-4c31-9f72-581de179c84a"), 3, "Thanh Xuân Nam", "Phường Thanh Xuân Nam", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("cd81dcbf-6837-4fa7-a9cf-536c77880ec9"), 3, "Cửa Nam", "Phường Cửa Nam", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("cd872bbe-d1e9-4f79-aed4-91917b489a8e"), 3, "15", "Phường 15", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("cda9fab4-3cd1-4e5b-ad95-649ab35b9d33"), 3, "Phú Diễn", "Phường Phú Diễn", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("cdc36184-a68f-4902-8d4e-86d5b2446040"), 3, "Cam Thượng", "Xã Cam Thượng", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("ce96760b-add1-47a6-8ba7-c716b1cb2c14"), 3, "Hoàng Văn Thụ", "Phường Hoàng Văn Thụ", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("cfb3ee22-f046-4d8f-b487-e60670dedaf3"), 3, "Giảng Võ", "Phường Giảng Võ", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("cfcf14e9-e21f-41fb-acaa-c775101bc3dd"), 3, "4", "Phường 4", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("d05330a4-0de1-4694-9880-85c13dd52f21"), 3, "12", "Phường 12", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("d0ca6272-3973-48b5-8d8f-db9ac0aa1713"), 3, "Tương Mai", "Phường Tương Mai", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), 2, "1", "Quận 1", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("d1a8f5fa-9938-4671-b5c4-dbd1e436ac81"), 3, "Ngọc Lâm", "Phường Ngọc Lâm", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("d1aef24c-76af-4031-b749-8450f2045a58"), 3, "11", "Phường 11", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), 2, "Sơn Trà", "Quận Sơn Trà", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("d285807c-184c-4505-b39b-f15108486656"), 1, "Thái Bình", "Tỉnh Thái Bình", null, null, "Tỉnh" },
                    { new Guid("d2b07a01-640f-481e-b073-9133c9f19a26"), 3, "Tam Phú", "Phường Tam Phú", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("d33ed81f-3047-4c0b-8962-785f12557113"), 3, "16", "Phường 16", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("d3fb3985-3bbc-410f-834b-8556a80c3b21"), 3, "Bạch Đằng", "Phường Bạch Đằng", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("d4030a56-9b32-4c1f-a0ff-3aed71431ee1"), 3, "Nghĩa Đô", "Phường Nghĩa Đô", new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), null, "Phường/Xã" },
                    { new Guid("d5e033b9-7eb3-4a06-ac22-6a983c657f4a"), 3, "Cam Phú Bắc", "Phường Cam Phú Bắc", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("d5fd1f3f-52c6-4ff4-b385-e3ba37350599"), 3, "Hòa Hải", "Phường Hòa Hải", new Guid("88fcc7a5-0c04-448f-9239-6c19d377884e"), null, "Phường/Xã" },
                    { new Guid("d693de7c-fbb9-4fec-a4e1-4b88caee14bc"), 3, "Phường 20", "Phường 20", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("d6de1cd7-94e3-4f61-b464-167ed8ce2b5f"), 2, "Bắc Cầu Giấy", "Quận Cầu Giấy", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("d745f532-c956-4413-b72f-effd273b27d5"), 3, "Liễu Giai", "Phường Liễu Giai", new Guid("51438fd1-5fcf-47b3-a3ea-6183887cb20e"), null, "Phường/Xã" },
                    { new Guid("d7d0f711-ad45-448e-90c7-b779402c3191"), 3, "Nguyễn Du", "Phường Nguyễn Du", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("d92f8a1f-9ef9-4a18-9c00-b5b6d1ca8bfc"), 3, "Hòa Khương", "Phường Hòa Khương", new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), null, "Phường/Xã" },
                    { new Guid("d993c740-41bd-4f8d-b7ae-a6e4ca601537"), 3, "Thịnh Quang", "Phường Thịnh Quang", new Guid("a43db02e-6ab4-4ca9-93b1-f8f4fd1199dd"), null, "Phường/Xã" },
                    { new Guid("d9b45c20-63a3-485c-b54e-8b5bfca4377d"), 3, "13", "Phường 13", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("da2cf89a-964b-41b7-bdd6-b5add5dcfea9"), 3, "Phường 9", "Phường 9", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("da843a05-8833-453b-912d-334bc1f799e0"), 3, "Phú Đông", "Xã Phú Đông", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("dafc861d-b296-4a6e-aa9e-c47b1136a13c"), 3, "Xuân Đỉnh", "Phường Xuân Đỉnh", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("db173b07-712a-448a-9710-410df58de082"), 3, "11", "Phường 11", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("db4b84c8-b14f-42c6-b0ad-50f999681371"), 3, "Hoàng Văn Thụ", "Xã Hoàng Văn Thụ", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("dbc7c68f-289f-4acf-902f-818939378549"), 3, "Phường 12", "Phường 12", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("dbcb7436-9f78-453b-b05a-a7499575d4a1"), 3, "Phương Canh", "Phường Phương Canh", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("dc12ad30-e1ab-4530-9422-a8dba703d07e"), 3, "Thái Hòa", "Xã Thái Hòa", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("dc86c073-f705-4719-90a7-17c180857818"), 3, "Khánh Trung", "Xã Khánh Trung", new Guid("6da0e1e2-7da9-4d13-97cb-abf993072df3"), null, "Phường/Xã" },
                    { new Guid("dca0cb34-c16b-458d-a325-2a30057365bb"), 3, "Nguyễn Cư Trinh", "Phường Nguyễn Cư Trinh", new Guid("d18996f9-2298-4218-b671-4ed4d8b798a5"), null, "Phường/Xã" },
                    { new Guid("dcdfc39f-6b53-4dca-a091-08da588d56c5"), 3, "6", "Phường 6", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("dd12f884-b721-4633-9eb2-37104be632f7"), 3, "Phường 9", "Phường 9", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("dd83be6d-a736-4fb3-a023-75b3be977a55"), 3, "Thanh Nhàn", "Phường Thanh Nhàn", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("dd83c12f-2d94-45ec-9fb0-b6f764d909f3"), 3, "7", "Phường 7", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("df7ef194-1573-4e85-8578-306c5bcf1357"), 3, "Đức Thuận", "Phường Đức Thuận", new Guid("24b62611-1759-45bc-a0a7-ab678c9ba256"), null, "Phường/Xã" },
                    { new Guid("df7f0dda-ed49-4739-a0ce-30f44fc77515"), 3, "Ngọc Thụy", "Phường Ngọc Thụy", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("df98d86f-96f1-4849-afbb-672392d7f001"), 3, "Bình An", "Phường Bình An", new Guid("9dde39c2-b8b9-4d35-b115-74315fe0ba17"), null, "Phường/Xã" },
                    { new Guid("e0245ab4-1b55-4e22-b178-b2fd345f7a5f"), 3, "Quang Trung", "Phường Quang Trung", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("e0a681bb-b38a-4787-ab3b-2d9df9bf33cf"), 3, "Sơn Đà", "Xã Sơn Đà", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("e386160d-3c5a-4241-8937-5ed352f1ba55"), 3, "Trường Thọ", "Phường Trường Thọ", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("e3db9494-4a6c-413e-8916-0a3b6f66f443"), 3, "Tân Thới Hiệp", "Phường Tân Thới Hiệp", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("e4452742-a285-471e-bff1-629ec2517fd7"), 3, "Nại Hiên Đông", "Phường Nại Hiên Đông", new Guid("d227a999-6712-4e27-b93c-e4a0de49b16c"), null, "Phường/Xã" },
                    { new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), 1, "Hồ Chí Minh", "TP.Hồ Chí Minh", null, null, "Tỉnh/Thành" },
                    { new Guid("e4c9748b-5118-4a0d-bab6-e75f51ef7ae4"), 3, "Thanh Trì", "Phường Thanh Trì", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("e562bde9-946f-45bc-ba3b-01e22f4a6376"), 3, "Phúc La", "Phường Phúc La", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("e57e3a55-0200-48f7-afdf-d3c059cb17bf"), 3, "Thụy Hương", "Xã Thụy Hương", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("e665bc61-e124-4e56-818c-892354321afc"), 3, "Phú Thượng", "Phường Phú Thượng", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("e68e9ba4-d086-484b-b1d3-5032a699bc9f"), 3, "Hiệp Bình Chánh", "Phường Hiệp Bình Chánh", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("e7405c31-bf77-46b0-a235-5bad8f79a78e"), 3, "14", "Phường 14", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("e79ff5e4-3f2b-4001-9c71-b910d638e9a8"), 3, "Tam Bình", "Phường Tam Bình", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), 2, "12", "Quận 12", new Guid("e460197d-0956-4eb3-8363-5bd892d1ea36"), null, "Quận/Huyện" },
                    { new Guid("e864101c-e12d-4d95-b623-7109ddd2c3cb"), 3, "Trung Văn", "Phường Trung Văn", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("e86b450d-74c8-44f4-aea6-8723b62890f9"), 3, "Quỳnh Mai", "Phường Quỳnh Mai", new Guid("7be70774-4b61-466c-a8a2-bdae4dc15448"), null, "Phường/Xã" },
                    { new Guid("e8e24bb7-7248-4cc5-9960-67d896936b4d"), 3, "17", "Phường 17", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("e8ff6d1c-1bb4-4bda-9430-6b2fcc7f4d80"), 3, "Thạch Thang", "Phường Thạch Thang", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("e93b5df2-9ac1-4897-9fb6-71a8e6d019a4"), 3, "10", "Phường 10", new Guid("303eaf9e-12a9-412c-b786-0c57c2458d0a"), null, "Phường/Xã" },
                    { new Guid("e979e0fd-69c9-4475-b31e-78ed1ede9d1f"), 3, "Đồng Thái", "Xã Đồng Thái", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("e9951353-55f4-4b3f-9106-e80652724ae9"), 3, "Châu Sơn", "Xã Châu Sơn", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("e99c4c51-8239-4230-bc13-7645b492266e"), 3, "6", "Phường 6", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("e9a9f213-2d2a-4e79-a1e1-e100a716a4d1"), 3, "Xuân La", "Phường Xuân La", new Guid("7748e80c-f132-40ae-a85a-bbd130e22993"), null, "Phường/Xã" },
                    { new Guid("ea07bc49-4093-4c9b-8c72-9a7e29993a8d"), 3, "Đại Nài", "Phường Đại Nài", new Guid("57c28592-b979-42a9-9a8b-f71c7e21c01a"), null, "Phường/Xã" },
                    { new Guid("ea180e4b-4b69-4938-8733-6ca852dca5f2"), 3, "6", "Phường 6", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("ea189f9c-e88d-49ac-b6aa-06420e07be4e"), 3, "Đồng Lạc", "Xã Đồng Lạc", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("ea2bc22e-14ee-4587-b069-8b6746e985cf"), 3, "9", "Phường 9", new Guid("c62bb4bc-ed58-4d24-969d-1f8217604943"), null, "Phường/Xã" },
                    { new Guid("ea605aee-22d7-423e-a04d-52b776c8f29a"), 3, "13", "Phường 13", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("ea6f63e2-b376-42d6-bf28-c5a4d9fa5353"), 3, "17", "Phường 17", new Guid("01558079-0710-4141-a885-e8c25ba6adcf"), null, "Phường/Xã" },
                    { new Guid("eaa3e347-f6f0-482f-a8b8-450190c2220f"), 3, "Phước Tân", "Phường Phước Tân", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("eac15025-21aa-4c02-a12f-bd93afe09e75"), 3, "Phường 11", "Phường 11", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("ead03d77-eaba-4306-b029-907eb3bb9829"), 3, "Tràng Tiền", "Phường Tràng Tiền", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("eb277942-30ad-4c8e-8bbd-cc6bbbf5db03"), 3, "Linh Xuân", "Phường Linh Xuân", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), 2, "Long Biên", "Quận Long Biên", new Guid("ab0a3d49-4943-447d-a755-c13b00f8181d"), null, "Quận/Huyện" },
                    { new Guid("eb99684f-57db-44c4-aaa7-304140aa42ef"), 3, "Phường 2", "Phường 2", new Guid("158d1541-bd3f-4d74-b860-f7a7815e7db7"), null, "Phường/Xã" },
                    { new Guid("ebf6334e-c236-4648-9f05-62db711d4f99"), 3, "Hàng Bài", "Phường Hàng Bài", new Guid("8fe57af2-b1f5-4f21-91f5-4cbee0e0926b"), null, "Phường/Xã" },
                    { new Guid("ec1c704c-fa8e-45ee-9f96-7355797978b3"), 3, "Diên Toàn", "Xã Diên Toàn", new Guid("60eab0c3-bed9-4bd6-807a-ea1115dcf3ed"), null, "Phường/Xã" },
                    { new Guid("ec73ab6f-8a12-49c0-b63d-21cc5b5edd78"), 3, "Trường Thạnh", "Phường Trường Thạnh", new Guid("1d924d2c-a3d1-4e9a-b7c6-599a84a0fcdc"), null, "Phường/Xã" },
                    { new Guid("ed1fe8f5-6f8d-4231-82fa-de4a731955d2"), 3, "Liên Mạc", "Phường Liên Mạc", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("ed8166e8-537b-4afe-bb30-ebc788a178bc"), 3, "Quang Trung", "Phường Quang Trung", new Guid("a1dc85ea-fdbe-4603-ac5c-e9871da7ba73"), null, "Phường/Xã" },
                    { new Guid("ee3915a0-b348-4fdd-b6a6-1f4744616cb3"), 3, "Phường 7", "Phường 7", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("eef527df-131e-4e45-bf42-ebca5d2fb49c"), 3, "Phường 10", "Phường 10", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("f0316559-c015-4d21-96f1-e3f8bba0a16a"), 3, "Bình Hiên", "Phường Bình Hiên", new Guid("bdd49c9a-01ee-4d69-9e26-10af8e1f61f7"), null, "Phường/Xã" },
                    { new Guid("f135c9ee-f724-431b-832a-6518ad26fc29"), 3, "Bồ Đề", "Phường Bồ Đề", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("f14916d7-5c9c-43d3-8c16-636c4c47be5f"), 3, "2", "Phường 2", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("f17f6035-9a70-4176-90aa-977c81eff307"), 3, "Phường 15", "Phường 15", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("f218d15d-94f4-4905-82bd-652ceb74c65e"), 3, "Tân Thới Nhất", "Phường Tân Thới Nhất", new Guid("e7acfbda-7650-4013-ab3c-d274a1f7c7c3"), null, "Phường/Xã" },
                    { new Guid("f2448276-7f1b-4dea-bd2a-e05bfe549fa0"), 3, "Trung Hòa", "Xã Trung Hòa", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("f28f4a3a-1da4-401e-a538-1ef6d803266c"), 3, "Vĩnh Hải", "Phường Vĩnh Hải", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("f298f4d4-89f1-4b22-9308-27ce79c86c78"), 3, "Gia Thụy", "Phường Gia Thụy", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("f2d8408f-aca8-464a-b0df-da133d80c033"), 3, "Phường 4", "Phường 4", new Guid("b0d2839e-183c-43f2-9209-d697df7860d4"), null, "Phường/Xã" },
                    { new Guid("f2ff3248-cbb2-41ef-a4b7-407432970b10"), 3, "Phụng Châu", "Xã Phụng Châu", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("f3207051-ade5-4fbf-8c06-c1492412fb66"), 3, "Yên Nghĩa", "Phường Yên Nghĩa", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("f36280a3-e05e-46b6-b5bf-dcf543281101"), 3, "Hạ Đình", "Phường Hạ Đình", new Guid("299c54bf-c324-43c7-997a-6cce1e1bb4e6"), null, "Phường/Xã" },
                    { new Guid("f3f836c8-5fae-41ae-a190-01f22f7bb859"), 3, "Minh Quang", "Xã Minh Quang", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("f4ed60ba-e570-4e85-9ac9-38cdade14886"), 2, "Hương Sơn", "Huyện Hương Sơn", new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), null, "Quận/Huyện" },
                    { new Guid("f58b06b8-bb4c-4d13-bc63-aa5e092d7949"), 1, "Hà Tĩnh", "Tỉnh Hà Tĩnh", null, null, "Tỉnh/Thành" },
                    { new Guid("f5e501b9-b609-4e04-8526-2473865e53af"), 3, "Cam Thuận", "Phường Cam Thuận", new Guid("a82d16b2-87ad-4efd-b9be-f44c8a2489f9"), null, "Phường/Xã" },
                    { new Guid("f6308bb2-68b9-4158-aa6f-09cd770aa048"), 3, "10", "Phường 10", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("f6e1a3f0-26a9-4926-a394-f66d4a050329"), 3, "Phú Châu", "Xã Phú Châu", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("f81a4735-df97-4bc5-9981-f8b72a0b5b2d"), 3, "Phường 6", "Phường 6", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("f883c0ea-a18a-4334-be88-83ede3003098"), 2, "Linh Chiếu", "Quận Linh Chiếu", new Guid("0140f9e9-5fa0-4bdb-bffb-b2c4fe4c3ec9"), null, "Quận/Huyện" },
                    { new Guid("f8e9da71-c8b8-4c68-94b5-1c4df0259002"), 3, "Nguyễn Trãi", "Phường Nguyễn Trãi", new Guid("b192232c-1639-49db-825a-963f7cb61b95"), null, "Phường/Xã" },
                    { new Guid("f9f8b356-d9f9-490a-b747-bc027c092028"), 3, "Trần Phú", "Xã Trần Phú", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("fa0ced05-5888-43ed-b8c6-a0739244098a"), 3, "Hoàng Liệt", "Phường Hoàng Liệt", new Guid("bbbae337-294b-4535-ac03-57c9465fb77c"), null, "Phường/Xã" },
                    { new Guid("fa20b1e6-55a5-4035-b7f2-d5e05d8e1bb2"), 3, "Xuân Phương", "Phường Xuân Phương", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("fa7640c8-6904-4982-bf6b-1077bfb819c5"), 3, "Đức Giang", "Phường Đức Giang", new Guid("eb73f3a7-d6e8-4c56-8149-e6e45052cd3f"), null, "Phường/Xã" },
                    { new Guid("faf57b0a-6fb5-457b-9d94-21f78a41e581"), 3, "Phương Sài", "Phường Phương Sài", new Guid("1ad0946c-b04c-4f57-9f3f-68f93a6ab624"), null, "Phường/Xã" },
                    { new Guid("fb034550-cb4e-434a-a84b-1ac974463760"), 3, "3", "Phường 3", new Guid("aac2fe9d-cc17-44fd-a065-6c99d9c4cad5"), null, "Phường/Xã" },
                    { new Guid("fb66a98c-92c2-4e76-8d4c-784d94c92349"), 3, "12", "Phường 12", new Guid("257f44b6-5ce3-4052-9d67-f6f7bcd16210"), null, "Phường/Xã" },
                    { new Guid("fbb40a92-77c8-4b32-b031-4c2d2ff5a13f"), 3, "Ba Vì", "Xã Ba Vì", new Guid("453fe1e3-207a-462f-b7b5-e9d7f876c68e"), null, "Phường/Xã" },
                    { new Guid("fc606b30-2806-4e45-84ba-e094e9ba8465"), 3, "3", "Phường 3", new Guid("49a31a33-2137-4e55-9345-1197103b429a"), null, "Phường/Xã" },
                    { new Guid("fc7ac97f-82af-4c6c-8d36-d1e8126fead2"), 3, "Mễ Tri", "Phường Mễ Tri", new Guid("c89114d4-5c9e-45c4-b66d-22268860d81a"), null, "Phường/Xã" },
                    { new Guid("fd7e42e0-48df-4562-babf-e91974051e92"), 3, "Đông Ngạc", "Phường Đông Ngạc", new Guid("644d658b-dcac-42c6-90af-22e527f9e2b6"), null, "Phường/Xã" },
                    { new Guid("fe4dc063-8bfe-4962-b1b0-52a846619547"), 3, "Phường 12", "Phường 12", new Guid("50245f51-ef5b-4639-851f-7e92bf7d0f11"), null, "Phường/Xã" },
                    { new Guid("fe75986d-f2ff-4fd6-a955-3059952c4ac5"), 3, "12", "Phường 12", new Guid("9d3285d1-ff8a-44e0-a3c4-be8ab5b449f9"), null, "Phường/Xã" },
                    { new Guid("fea815bc-e258-40bf-80e1-37bc14b7411c"), 3, "Thượng Vực", "Xã Thượng Vực", new Guid("87829a37-089f-4079-a68c-2ceebabe9a8a"), null, "Phường/Xã" },
                    { new Guid("ffb45fa2-cbc6-4af6-a99b-899322b069af"), 3, "Xuân Hà", "Phường Xuân Hà", new Guid("815a6281-8f81-45f4-bc6d-4b052342857e"), null, "Phường/Xã" }
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
                columns: new[] { "PostId", "AccountModelAccountId", "Alias", "Author", "Contents", "CreateDate", "IsHot", "IsNewFeed", "MetaDesc", "MetaKey", "Published", "Tags", "Thumbnail", "Title", "View" },
                values: new object[,]
                {
                    { new Guid("0244ee11-e16c-4a0e-9218-8e55a53a1640"), null, "jennifer-belle-gets-brave-and-regrets-everything", "David Adams", "Things couldn’t have gone much better for a 28-year-old debut author in 1996. There were blurbs from Jay McInerney (“a funny, sad, nasty little gem of novel”) and Tama Janowitz (“hilariously enthralling”). Madonna optioned the film rights—and wanted to direct. “Best new novelist,” declared Entertainment Weekly. “I think I was in 14 magazines at the same time, on a newsstand on my corner,” Jennifer Belle says via Zoom from her art-cluttered apartment overlooking New York City’s Washington Square Park.\r\n\r\nAnd then there was the dead fish. A bucket of them, to be precise, brought to Belle’s first Greenwich Village apartment by a photographer on assignment. “We spent a whole day shooting,” she recalls, “and somehow in the end, the picture—a full page in New York magazine—is me with a real dead fish on my head. There was a really nice one, where I’m kind of leaned over. Like, I have a headache and I’m holding the fish like a hot compress.” She recreates the pose with her iPhone. “But that’s not the one they used.”\r\n\r\nIf ever there was a debut novelist who didn’t need a prop, it was Belle. Her downtown “it girl” resumé would have been enough to make Chloë Sevigny jealous: the daughter of poet Jill Hoffman, Belle dropped out of high school at 15, lied her way into a job at a Bleecker Street bar, played a young Penny Arcade in the performance artist’s shows at La MaMa theater, and started her novel, Going Down, to have something to read at her mother’s writing workshops. By the time the book came out, she was selling luxury apartments for the Corcoran Group. The one job she’d never had, Belle informed New York’s profile writer, was the occupation Going Down’s 19-year-old protagonist takes up to pay for college: call girl. That is indeed what happens in the summer of 1982 to Swanna Swain. Her parents, like Belle’s, are recently separated. Her mother, like Belle’s, is a Guggenheim-winning poet. Her interests, like Belle’s, would run screaming from the snake-infested woods of Vermont, where her mom’s new boyfriend has a room at an artists’ retreat, and toward the landmarks of 1980s Manhattan: Canal Jeans, O’Neals’ Baloon, Woody Allen.\r\n\r\nThen the novel, which Akashic describes as “a kind of inverse Lolita,” reaches its midway point, and Swanna does something Belle never did. “I never got into an older man’s car and went to his house for two days or three days while his wife was away in England,” she says. “It’s more of a composite of older men I dated, which was not unusual back in 1982 or ’3 or ’4 or ’5, or probably today. I mean, I don’t know anybody who didn’t make out with the bartender at their friend’s bar mitzvah or the limo driver at the prom.”\r\n\r\nIs it wise for a novelist with a history of being confused for her characters to write about a teenage seductress? Maybe not. But Belle, who’s girded herself for her first interview in 12 years with red lipstick and a pair of miniature Barbie doll earrings, is the type of raconteur who can’t resist a good punchline, even when she knows it’ll get in her trouble. “Your editor thought you’d be a good match for a book about pedophilia?” she quips, two minutes into our conversation.\r\n\r\nIn a more reflective moment, Belle says that Swanna “never feels like a victim. I think she probably is a victim because she’s 14 and she’s having an affair with a 37-year-old married man. But she doesn’t feel that way for one minute. She thinks she’s in control and she really thinks she’s in love.”\r\n\r\nThough the parallels to Lolita are clear, a different novel served as the inspiration for Swanna’s story: Charles Portis’s True Grit. Belle, who was given a copy by someone in her writing workshop—she runs four of them out of her apartment and has helped shepherd into print novels by Nicola Harrison and Marilyn Simon Rothstein—says it “looked like nothing I would be interested in whatsoever. It has a gun on the cover. But something about reading this book about a 14-year-old girl who sets out to avenge her father’s murder—and she’s unapologetic and she’s cool and she’s tough—something just went off in my head. That I could tell my story the way I wanted to tell it. But I had to make the book more than just being picked up and going to this artist colony that didn’t allow kids. So, I added stuff.”\r\n\r\nOf course, it’s the stuff Belle added that may land her in hot water. Why take the risk? Partly, she says, because she’s “so unhappy with the state of publishing—the censorship going on all over the place.” Asked for an example, she points to a former member of her workshop, Jeanine Cummins, whose 2020 bestseller American Dirt met with fierce backlash from Latinx writers who accused Cummins and her publisher, Flatiron Books, of exploiting their stories.\r\n\r\n“Basically, every single publishing house wanted this book,” Belle says. “And by the end of her journey, she was canceled. All the publishers should have stood up and said, ‘We wanted this book. We decide who gets to tell what story. Not one person on the internet.’ ”\r\n\r\nBelle notes that when her agent, Sterling Lord Literistic’s Doug Stewart (who also reps Cummins), sent Swanna in Love “around to all the big people, they said, ‘Great writing. We love her. But we don’t have a vision for it.’ That was the word I got. I thought I’d be on Zooms with people, and they’d say, ‘Let’s make her older,’ or, ‘Let’s make him younger.’ But what I found were no Zooms, just this language about ‘vision.’ ”\r\n\r\nBelle counts herself lucky to have landed at Akashic, which she’s admired “from the very beginning” (her friend Arthur Nersesian’s The Fuck-Up was the indie press’s first release, in 1997). And while the crusader in her is ready to defend the idea that “people have the right to write whatever they want,” the novelist in her is mainly just thrilled to have unlocked a story she’s been trying to tell for a long time.\r\n\r\nOriginally planned as a flashback in another novel, Swanna in Love came “pouring out” of Belle during Covid lockdowns, when she spent 14 weeks with her husband and two sons in their Hudson Valley country house. “I had never spent 14 days in that house,” she says. “And what I discovered is, I really don’t like it there. I just hated it so much. Something about connecting with that feeling of powerlessness, of having no control over your environment, like when you’re 14 or 15 or 16, brought this character out of me.”\r\n\r\n“I have spent a decade helping other people get published,” Belle says at another point in the conversation. “And writing also, but not writing what I wanted to write. And then something changed. I got brave. Maybe I’ll change my mind. I’ve regretted everything I’ve ever done in my life, so it wouldn’t surprise me.”", new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8778), true, true, "Jennifer Belle Gets Brave and Regrets Everything", "Jennifer Belle Gets Brave and Regrets Everything", true, "Jennifer Belle Gets Brave and Regrets Everything", "jennifer-belle-gets-brave-and-regrets-everything.jpg", "Jennifer Belle Gets Brave and Regrets Everything", null },
                    { new Guid("1e009d2b-de3f-49fc-a82c-ee477fdb6489"), null, "fans-recharge-the-conmics-industry-at-new-york-comic-con-2023", "Heidi MacDonald", "New York Comic Con held an exhausting but exhilarating annual celebration of comics and pop culture October 12–15 at the Javits Center in New York City. While final attendance count is still pending, estimates are that crowds surpassed last year’s 200,000.\r\n\r\nThe show floor presented a psychedelic mash-up of pop culture, with manga and anime dominating. Massive character balloons of Goku from Dragon Ball and Luffy from One Piece loomed over the throngs, while immersive 3D manga displays from Shueisha and impressive activations from Crunchyroll, Manga Plus, and Bandai drew long lines. The prevalence of manga and anime-inspired costumes amongst cosplayers made clear just how much younger fans are riding the manga wave.\r\n\r\nFor publishers, it was a transitional year. Marvel was the only major comics publisher to invest in a prominent show floor presence, as DC, Dark Horse, and Image mostly sat it out, while IDW set up in Artist Alley on the lower level. But the gap left an opening for upstart exhibitors like Vault and Mad Cave to shine. And other new imprints, partnerships, and brands dotted the show floor.\r\n\r\nThe splashiest announcement was for Ghost Machine, added as an imprint at Image Comics led by veteran writer/producer and former DC Comics executive Geoff Johns. The brand promises a creator-owned line of comics with a shared universe and media development; creators involved include artists Gary Frank and Bryan Hitch and novelist Brad Meltzer. Also from Image, creator Rick Remender (Deadly Class) promoted his new Giant Generator imprint, sporting an international cast of creators including Daniel Acuña, Paul Azaceta, JG Jones, and Bengal. Another new player, Massive Publishing, serves as a publishing partner for various entities, such as collectibles auction app WhatNot and existing music-to-comics label Behemoth.\r\n\r\nThis buzz rose above reports of slower industry sales, discussed across the dedicated professional programming held Thursday. Direct market distributor Lunar kicked things off with a retailer breakfast, where Ghost Machine debuted. Retailer organization ComicsPRO followed with a slate of presentations, including updates on a metadata project that brings together an unprecedented mix of publishers, distributors, and retailers aiming to standardize industry metadata—with an eventual goal of sellthrough sales charts, now unavailable for the direct market.\r\n\r\nICv2’s presentation by Milton Griepp showed graphic novel sales strong and overall sales higher than 2019, but periodical comics sales slipping—even as the book market in general continues to soften following its pandemic highs. Concerns over inflation cutting into discretionary spending were also noted.\r\n\r\nYet the mood at the show was optimistic. Despite the high costs that prevented other publishers from exhibiting, Vault CEO and publisher Damian Wassel noted that Vault’s many readers in the NYC market made it worth their investment. “Attendance was incredible, and our sales were up dramatically over last year,” he said. “It's our best con ever.”\r\n\r\nMad Cave debuted recent licenses with Winx and Gatchaman, setting up their largest booth to date to showcase their expansion. “We got to show off Papercutz for the first time at NYCC [and] all the new things that we're doing, including more creator owned or licensed projects,” said CMO Allison Pond.\r\n\r\nAbrams ComicArts editor-in-chief Charles Kochman was pleased to see major book trade houses—including PRH, MacMillan, HarperCollins—and comics publishers united in one area on main the show floor. “By putting us together, you give people a sense of comparing and contrasting, but also there's a community among publishers,” he said.\r\n\r\nPRH highlighted their many genre imprints, along with new arrivals Ten Speed Graphic and a look-ahead to Inklore, a new imprint publishing manga, manhwa, and webtoons. According to PRH director of brand events Lindsey Elias, “people are super excited about Inklore and want to buy the [not yet released] books now,” adding: “We're able to do sales, marketing, and publicity all in one go.”", new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8767), true, true, "Fans Recharge the Comics Industry at New York Comic Con 2023", "Fans Recharge the Comics Industry at New York Comic Con 2023", true, "Fans Recharge the Comics Industry at New York Comic Con 2023", "fans-recharge-the-conmics-industry-at-new-york-comic-con-2023.jpg", "Fans Recharge the Comics Industry at New York Comic Con 2023", null },
                    { new Guid("23e9cf3b-bbf4-45b8-af03-ffde8fa81549"), null, "new-thrillers-about-true-crime", "Liz Scheier", "Amazon Publishing associate publisher Gracie Doyle understands the appeal of amateur sleuthing. “I can’t be the only kid who wanted to be a detective,” she says. “And with all of us home for a couple of years, there’s a Rear Window element. We all love a good mystery.”\r\n\r\nAmong the books on her list is Elle Marr’s The Alone Time (Thomas & Mercer, Mar. 2024), which sees long-buried truths coming to light. Twenty-five years after Fiona and Violet Seng survived the private plane crash that killed their parents and left the girls, then ages 13 and seven, stranded in the Pacific Northwest wilderness for three weeks, a persistent documentarian calls into question their version of the events.\r\n\r\nIn Janice Hallet’s The Mysterious Case of the Alperton Angels (Atria, Jan. 2024), two true crime authors tussle over the career-making untold story of a cultlike group who believed that the child of one of its members was the Antichrist. “There’s a fine line between what’s public safety and what’s invading people’s privacy,” says Atria senior editor Kaitlin Olson. “Amateur detectives can go too far. We’ve seen this play out in real investigations—while intentions are really good, people on social media can get in the way.”\r\n\r\nThe intentions aren’t even necessarily good in Dervla McTiernan’s What Happened to Nina?, in which a character posts videos with conflicting theories of what happened to a missing girl in order to sow confusion. (See PW’s q&a with Dervla McTiernan, “Trial by Internet.”) In Kellye Garrett’s next thriller, the entire internet is on the lookout for a woman who fits the ideal victim profile: a Missing White Woman (Mulholland, Apr. 2024; Garrett discusses the phenomenon in “Social Distortion.”)\r\n\r\nHusband and wife team Nicci Gerrard and Sean French, who’ve written numerous thrillers as Nicci French, probe the ramifications of reopening old wounds in their latest, Has Anyone Seen Charlotte Salter? (Morrow, Mar. 2024). The wife and devoted mother of the title disappears just before her husband’s 50th birthday party; when a neighbor’s body is found soon after, the police conclude that the two were having an affair and died in a murder-suicide. Thirty years later, the neighbor’s son produces a popular podcast about the tragedy, throwing both families into turmoil.\r\n\r\n“We need stories, they explain life to us,” Gerrard says; she and French are former journalists. “But sometimes there isn’t a shape to the mess of life. We read stories of serial killers, and when there’s no evident psychological motivation, it’s like trying to find a fingerhold in smooth rock.”\r\n\r\nAnything for the story\r\n\r\nJournalists are held to a standard the average TikTok creator isn’t, but they, too, can lose sight of the impact their work has on their subjects. Christina Estes draws on more than 20 years of reporting experience for her debut novel, Off the Air (Minotaur, Mar. 2024), in which journalist Jolene Garcia hopes that her investigation of a death at a local radio station will make her career. “She comes up against a line she isn’t sure she should cross,” says Minotaur associate editor Madeline Houpt. “She thinks, ‘Am I going too far?’ But she wants to solve the case.”\r\n\r\nJenny Hollander, director of content strategy at Marie Claire, turns the tables on a fellow journalist in her debut, Everyone Who Can Forgive Me Is Dead (Minotaur, Feb. 2024). Charlie Colbert, a successful magazine editor, witnessed a horrific event at her journalism school nine years earlier. When she learns that one of her former classmates is making a movie about the event, known as the Scarlet Christmas, Charlie worries that the truth will come out. “She doesn’t totally remember what happened,” says St. Martin’s editor Sallie Lotz, who edited the book. “But she knows she lied about it.”\r\n\r\nAlmost Surely Dead by Amina Akhtar (Mindy’s Book Studio, Feb. 2024) tells the story of Dunia, a woman who is attacked on the subway, unravels, and then goes missing. Two obsessed journalists launch a true crime podcast seeking fame from Dunia’s misfortune: they want a Netflix deal, they’re selling merch. “I wanted to dive into trauma as content,” Akhtar says. “There should be a code of ethics for true crime. Something horrible happened to somebody; if the family is willing to talk to you, you’re probably walking the right line. If someone doesn’t want their story told, whose decision is it to tell it? Who owns the story?”\r\n\r\nJason Pinter explores the tension between truth-telling and entertainment-selling in Past Crimes (Severn House, Feb. 2024), set in a near-future where true crime fans can immerse themselves in hyper-realistic simulations of gruesome historical killings; people can pay to search for clues inside Jeffrey Dahmer’s Wisconsin cabin, for instance, or attend Lincoln’s assassination. “In these virtual experiences, the evilness has been taken out,” Pinter says. “All we’re left with is the entertainment.”\r\n\r\nIn Jeffrey B. Burton’s The Dead Years (Severn House, Mar. 2024), a long-dormant serial killer sees a Netflix docudrama based on his crimes, and isn’t happy about his portrayal. “Morbid curiosity is a universal trait,” Burton says. “Every day in some paper somewhere around the world, there’s a story that proves truth is stranger than fiction—‘Holy shit, what did the guy do?’ ”", new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8770), true, true, "New Thrillers About True Crime", "New Thrillers About True Crime", true, "New Thrillers About True Crime", "new-thrillers-about-true-crime.jpg", "New Thrillers About True Crime", null },
                    { new Guid("5e421559-0ac4-4588-97bc-48bbf2b07c44"), null, "the-forest-fires-of-greece-wreathe-christy-lefteri's-latest-novel", "Elaine Szewczyk", "Lefteri’s new novel, The Book of Fire, due out in January from Ballantine, addresses climate change as it follows a contemporary Greek family—music teacher Irini; her painter husband, Tasso; and their daughter, Chara—who live in a village in an ancient forest and whose lives are upended when a fire erupts, decimating both forest and village. The villagers blame a developer who started the fire while clearing land to build a hotel, but he isn’t the sole culprit, as prolonged high temperatures created dry conditions that turned the forest into a tinderbox.\r\n\r\n“How do we deal with situations where there’s someone to blame, but there’s also something bigger happening?” Lefteri says. “And how do we deal with that during times of trauma?”\r\n\r\nThe first time Lefteri saw an out-of-control forest fire in Greece was in 2017, when she was working as a volunteer at an Athens refugee center for women and children who’d been displaced during the Syrian Civil War. “I woke up one morning and the sky was filled with smoke,” she recalls. “There was a fire in a nearby town. It haunted me.”\r\n\r\nLefteri decided to write The Book of Fire in 2021, after another, bigger fire on the Greek island of Evia destroyed an ancient forest, killed more than 100 people, and left others homeless and physically scarred. She went to Greece for six weeks, while three months pregnant, to do research for the novel.\r\n\r\nThis included visiting the town of Mati, the site of yet another fatal fire, in 2018, and talking with still-traumatized locals, many of whom rejected the idea that climate change was responsible.\r\n\r\n“Being there was overwhelming,” Lefteri says. “I wanted to leave, which I felt horrible about. Every time I write a book I feel guilt, about being able to go home, a home that hasn’t been destroyed, that isn’t a camp. There’s this thing that happens to me where I become frightened about life. I can be quite robust, but when I’m alone I feel the fragility of life. It gets to me. I find it hard to regain my grounding, but then I remember what other people are dealing with.”\r\n\r\nLefteri is disarmingly open about her personal life and displays a genuine interest in others, which makes her effective as a field researcher who’s willing to be the sympathetic ear. “Christy is one of the most caring and compassionate people I’ve ever met,” says Lefteri’s agent, Marianne Gunn O’Connor. “She has a beautiful personality and a sweet nature. She worries about the world and writes with her heart.”\r\n\r\nBorn in 1980 in London, Lefteri was a sensitive child who enjoyed oil painting and stories. Her father, who’d been an officer in the war in Cyprus in 1974, came to the U.K. with Lefteri’s mother. Lefteri remembers her childhood home as a warm place, but her father, who she says had undiagnosed PTSD, was prone to outbursts. “That was the impact of someone not speaking about their trauma,” Lefteri explains. “I remember thinking as a child, what am I doing wrong? I still carry that. I’m constantly thinking I’m doing something wrong. That’s how unspoken trauma gets passed from one generation to the next.”\r\n\r\nAs she grew older, Lefteri became interested in writing as a way to express trauma. She worked for a time as a psychoanalyst, and in 2010 she earned her PhD in creative writing from Brunel University and wrote her first novel, A Watermelon, a Fish and a Bible, about the war in Cyprus, as part of her thesis project.\r\n\r\n“Writing really gets to my heart,” says Lefteri, whose characters often use art to cope with their troubles. “I think sometimes we have to go into our pain to overcome it.”\r\n\r\nAnne Speyer, Lefteri’s editor, appreciates the author’s ability to make big topics feel accessible. “Christy is wonderful at taking things that you read about in the news and making them personal,” she says. “She also makes you feel deeply about her characters. That’s the key to a great story, and she’s done it with every book.”\r\n\r\nLefteri’s next novel will be about European women’s football and will be set during World War I and in the present as it explores women’s lives across generations. “The book is linked to what I experienced with my daughter’s dad after she was born,” Lefteri says. “I left like I had lost my independence, that everything was put on me. This book will be about women’s dreams, about how far we’ve come, and if we’ve come as far as we think.”\r\n\r\nAs evening sets in, Lefteri hears a voice downstairs and checks the clock. The nanny is about to leave and it’s time to get her daughter. The pair may go for a walk with their dog, Alfie. (An emphatic animal lover, Lefteri is “completely obsessed” with him.)\r\n\r\nShe hopes The Book of Fire will inspire people to pay attention to how humanity treats the planet and every living thing on it. “There’s a grief we feel at the loss of our environment, and we don’t often realize that it causes such sadness,” she says. “If we lose our world, we’re nothing. Perhaps this book can make people pause and feel. When we really feel, it can impact a decision.”\r\n\r\nElaine Szewczyk’s writing has appeared in McSweeney’s and other publications. She’s the author of the novel I’m with Stupid.", new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8773), true, true, "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", true, "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", "the-forest-fires-of-greece-wreathe-christy-lefteri's-latest-novel.jpg", "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel", null },
                    { new Guid("67815636-c308-41ad-ae14-f96806365d29"), null, "salar-abdohs-tehran-is a-city-of-contradictions", "Leigh Haber", "“I also wanted to have a reckoning with the revolution,” he says. “This move was arguably the foundational step of my life. I could have stayed away like so many exiles and lived a strictly America life. Very deliberately I chose not to.”\r\n\r\nMany of the geopolitical issues of the past 40-plus years, Abdoh contends, stem from the Iranian Revolution, which toppled the monarchy, led to the establishment of the Islamic Republic, and changed the balance of power in the Middle East. “As someone who wanted to be an adventurer even more so than I wanted to be a writer,” he says, “I thought, where else but Iran!”\r\n\r\nTehran, the sprawling city of 15 million where much of A Nearby Country Called Love is set, is portrayed as a place of infinite contradictions. Pollution, traffic jams, overflowing garbage, and precarious construction sites are parts of everyday life. Modesty squads patrol the streets, fining or arresting women for “improprieties” such as not wearing hijabs. There is a steady stream of news about women who choose to burn themselves to death rather than continue to be beaten by husbands, fathers, or brothers for perceived acts of defiance.\r\n\r\nAt the same time, Abdoh’s Tehran is a cosmopolitan city brimming with cafés, culture, and well-educated locals who frequent concerts, galleries, and literary readings. There is also a vibrant underground network of gay bars and drag clubs.\r\n\r\nBut no matter the neighborhood or occasion, there are some constants in Tehran. Among them, and reflected in the psyches of Abdoh’s characters, is dread. “While it’s not quite the quotidian oppression outsiders imagine, there is the sense of always being on edge,” he says. “That dread has become innate, part of our very character.” And yet, he adds, “at some point folk figured out that rather than fighting the authorities to keep them out of their lives, they can simply disregard and ignore them, which creates a schizophrenia that you learn to live with, though at a cost to your mental and physical well-being.”\r\n\r\nA Nearby Country Called Love, which PW’s review called “a moving and nuanced study of gender and sexuality in contemporary Iran,” follows Issa as he reluctantly returns to Tehran from New York City and attempts to come to terms with his brother’s death. As the novel opens, Issa and his friend Nasser are on a mission to avenge the suicide-by-burning of a wife whose husband, the pair believe, drove her to that fate. While Nasser, a fireman who moonlights as an appliance salesman, revels in the testosterone-fueled vigilante mission—their second—Issa, a former soldier, knows there is nothing noble about what they have set out to do. He is also reminded of the persecution his late brother Hashem faced in their neighborhood due to his sexual orientation.\r\n\r\nViolence threads throughout the novel, as do Issa’s questions about the nature of masculinity and what is expected of a man living in contemporary Iran.\r\n\r\n“My father was a boxer and a soldier,” Abdoh says. “Machismo was part of the fabric, part of the molecule of everything that I grew up with. But my brother Reza was into theater and the arts. At an early age, he knew he was gay, and my father viewed him with shame. I was always in the middle, being pulled in both directions. I modeled Issa’s brother on my family experience, and on what Reza endured and accomplished before he died of AIDS in 1995.”\r\n\r\nIssa lives above the dojo his father ran until his death. His brother Hashem was a revered queer artist in Tehran’s underground—and their father did everything he could to scare Hashem straight. After enduring bullying and beatings by schoolmates and his father, Hashem learned to be defiant no matter the price. His death devastated Issa and prompted him to learn more about the community of friends, lovers, and artists who embraced his brother.\r\n\r\nIssa starts by reading authors Hashem cherished: Beckett, Auden, Proust, and Rilke. Soon, he’s attending parties and performances with people in his brother’s circle. Boundaries melt away. Eventually, Issa becomes romantically involved with a man. For Issa, though, this is a process of self-discovery—and even a way of honoring his brother.\r\n\r\nReferences to various Western literary works are sprinkled throughout the narrative, as are mentions of Perso-Arabic classics. The latter, Abdoh says, “cast a huge shadow of influence for me because many of those writers and mystics were always after the ultimate questions. Ontology—the branch of metaphysics dealing with the nature of being—was their bread and butter.” The same can be said for Abdoh, whose work probes the nature of belonging, masculinity, and the self.\r\n\r\nAnd while Abdoh set the novel in Iran and many of its plot points are unique to that country, he also wanted to address the global question of “how to be a man in this day and age,” he says, “when the paradigm of who we are supposed to be has shifted and none of us really knows how to behave, to respond.”", new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8775), true, true, "Salar Abdoh's Tehran Is a City of Contradictions", "Salar Abdoh's Tehran Is a City of Contradictions", true, "Salar Abdoh's Tehran Is a City of Contradictions", "Salar-abdohs-tehran-is a-city-of-contradictions.jpg", "Salar Abdoh's Tehran Is a City of Contradictions", null },
                    { new Guid("9c32207b-bdf3-4e21-acc2-691a711ce129"), null, "tattered-cover-bookstore-files-for-bankruptcy", "Jim Milliot", "Tattered Cover Book Store, one of the country’s largest and best-known independent bookstores, filed for reorganization under Chapter 11 Subchapter V in the U.S. Bankruptcy Court for the District of Colorado yesterday. According to the Denver Post, documents filed in the bankruptcy court show Tattered Cover was more than $660,000 in the red between January and September. The business owes more than $1 million to publishers, as well as more than $375,000 to Colorado's Office of the State Auditor for abandoned gift cards.\r\n\r\nThe Subchapter V portion of Chapter 11 was enacted by Congress in 2020 to provide a streamlined process for small companies to reorganize. If the financing is approved, Tattered Cover will have access of up to $1 million in debtor-in-possession financing, provided by a new company formed by current company board members and investors that include Leslie Rainbolt and Margie Gart. The new funding, the announcement said, “will be used to obtain much-needed additional inventory in time for the critical 2023 holiday consumer buying season, fulfill customer orders, upgrade technology, and to maintain operations and staff compensation during the restructuring process.”\r\n\r\nVarious companies that supply books to Tattered Cover said that they will need to time to get a better understanding of the store's new financing before deciding on how to continue to work with the store in the future. The store has been on credit hold with a number of publishers.\r\n\r\nThe current owners, Bended Page LLC, acquired Tattered Cover in 2020 and, after an initial period of expansion, found business slowing, due in part to the pandemic. The bookstore also endured some management changes when Kwame Spearman, one of the lead investors who was named CEO, stepped down from that position in April after deciding to run for mayor of Denver. He subsequently withdrew from that race, and is now running for the Denver school board.\r\n\r\nIn July, Brad Dempsey, a lawyer specializing in finance and business restructuring, was named interim CEO. “Our objective is to put Tattered Cover on a smaller, more modern and financially sustainable platform that will ensure our ability to serve Colorado readers for many more decades,” Dempsey said in a statement. “Restructuring for long-term viability requires managers to make very difficult business decisions that affect people and business partners, and we intend to do what we can to minimize these impacts.”\r\n\r\nDempsey was referring to a host of changes that are in the process of being implemented. Among them are closing three of its seven stores: the locations in Denver’s McGregor Square, Westminster, and Colorado Springs. Those stores are expected to be closed by early November, at which time inventory and technology from the three will be transferred to the store’s four other locations.\r\n\r\nThe store closures will result in cutting “at least” 27 staff positions out of Tattered Cover’s current 103 positions, though the company said that some employees may fill temporary seasonal positions at the remaining stores during the holiday season. Tattered Cover’s Denver International Airport locations will continue operating, as part of a licensing agreement with Hudson Bookstores.\r\n\r\nIn addition to Dempsey, the company’s restructuring will be led by its senior management team: CFO Margie Keenan, newly named COO Jeremy Patlen (formerly v-p of buying), and Alexis Miles, v-p of human resources.\r\n\r\nThe company said that all customer gift cards will be honored, and orders will continue to be fulfilled, while all loyalty programs will also continue as usual. Events currently scheduled for this October and November at closing locations will be rescheduled, if possible, to take place at the store’s remaining locations, with all event changes to be posted on the bookseller's website.\r\n\r\nThe original Tattered Cover was opened in 1971 by Stephen Cogil and purchased by Joyce Meskis in 1974. Meskis sold it to Len Vlahos and Kristen Gilligan in 2015, who sold it to the current owners. The store is considered among the leading independent bookstores in the country, and has a long history of being at the forefront in the fight for free speech and First Amendment rights.", new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8760), true, true, "Tattered Cover Book Store Files for Bankruptcy", "Tattered Cover Book Store Files for Bankruptcy", true, "Tattered Cover Book Store Files for Bankruptcy", "tattered-cover-bookstore-files-for-bankruptcy.jpg", "Tattered Cover Book Store Files for Bankruptcy", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5b71c14d-aedb-41e1-a1d9-943fd5d3983c"), "Admin" },
                    { new Guid("e9bb47a8-d3fc-409c-8651-0542816f7483"), "Nhân Viên" }
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
                table: "Books",
                columns: new[] { "BookId", "Active", "Alias", "Author", "BestSellers", "BookDescription", "BookName", "CategoryId", "CreateDate", "Discount", "HomeFlag", "MetaDesc", "MetaKey", "OriginalPrice", "Price", "Tags", "Thumbnail", "Title", "UnitsInStock" },
                values: new object[,]
                {
                    { new Guid("0e57fdb0-760c-47d6-90c9-50a6128c69c7"), true, "he who drowned the world", "Shelley Parker-Chan", true, "Zhu Yuanzhang, the Radiant King, is riding high after her victory that tore southern China from its Mongol masters. Now she burns with a new desire: to seize the throne and crown herself emperor.", "He Who Drowned the World", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8710), 20, false, "He Who Drowned the World", "He Who Drowned the World", 20f, 14f, "He Who Drowned the World", "he-who-drowned-the-world.png", "He Who Drowned the World", 10 },
                    { new Guid("111983d4-f66d-430f-91a8-d0b4e55257bf"), true, "witness-stories", "Jamel Brinkley", false, "From a National Book Award finalist, Witness is an elegant, insistent narrative of actions taken and not taken.", "Witness: Stories", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8689), 20, true, "Witness: Stories", "Witness: Stories", 22f, 16f, "Witness: Stories", "stories.png", "Witness: Stories", 10 },
                    { new Guid("14e2d84d-cbc2-417d-a0f2-134d8ef3cd33"), true, "the-frangitelli-mirror", "G.R. Thomas", true, "Rose Carbonelli sees ghosts. She doesn’t sleep. She watches every corner, studies every shadow, listens to the screams that no one else hears. Rose Carbonelli is terrified.", "The Frangitelli Mirror", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8662), 20, false, "The Frangitelli Mirror", "The Frangitelli Mirror", 19f, 14f, "The Frangitelli Mirror", "the-frangitelli-mirror.png", "The Frangitelli Mirror", 10 },
                    { new Guid("18e1ea97-4987-4ff6-8083-c324e70fbe15"), true, "milk-and-mocha-our-little-happiness", "Melani Sie", false, "An out-of-this-world new middle-grade graphic novel about a genius scientist and her evil nemesis—from New York Times bestselling author Laini Taylor and cartoonist Jim Di Bartolo", "Milk & Mocha: Our Little Happiness", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8676), 20, true, "Milk & Mocha: Our Little Happiness", "Milk & Mocha: Our Little Happiness", 15f, 10f, "Milk & Mocha: Our Little Happiness", "milk-and-mocha.png", "Milk & Mocha: Our Little Happiness", 10 },
                    { new Guid("250ab1d4-ba83-4bb9-8d9e-8f7f979e3327"), true, "kiss-the-girl", "Zoraida Córdova", false, "Ariel del Mar is one of the most famous singers in the world. She and her sisters—together, known as the band Siren Seven—have been a pop culture phenomenon since they were kids. On stage, wearing her iconic red wig and sequined costumes, staring out at a sea of fans, is where she shines. Anyone would think she’s the girl who has everything. ", "Kiss the Girl", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8679), 20, true, "Kiss the Girl", "Kiss the Girl", 15f, 10f, "Kiss the Girl", "kiss-the-girl.png", "Kiss the Girl", 10 },
                    { new Guid("26cc2cdf-fe3a-47a4-9979-f015ba3c81d9"), true, "the-shining", "Stephen King", true, "Jack Torrance's new job at the Overlook Hotel is the perfect chance for a fresh start. As the off-season caretaker at the atmospheric old hotel, he'll have plenty of time to spend reconnecting with his family and working on his writing. But as the harsh winter weather sets in, the idyllic location feels ever more remote...and more sinister. And the only one to notice the strange and terrible forces gathering around the Overlook is Danny Torrance, a uniquely gifted five-year-old.", "The Shining", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8600), 20, true, "The Shining", "The Shining", 14f, 10f, "The Shining", "theshining.png", "The Shining", 10 },
                    { new Guid("2a96a54a-0847-482b-802d-b6f4358270ea"), true, "the-exorcist-legacy-50-years-of-fear", "Nat Segaloff", true, "Since 1973, The Exorcist and its progeny have scared and inspired half a century of filmgoers. Now, on the 50th anniversary of the original movie release, this is the definitive, fascinating story of the scariest movie ever madeand its lasting impact as one of the most shocking, influential, and successful adventures in the history of film. Written by Nat Segaloff, an original publicist for the movie and the acclaimed biographer of its director, with a foreword from John Russo, author and cowriter of the seminal horror film Night of the Living Dead.", "The Exorcist Legacy: 50 Years of Fear", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8658), 20, false, "The Exorcist Legacy: 50 Years of Fear", "The Exorcist Legacy: 50 Years of Fear", 19f, 14f, "The Exorcist Legacy: 50 Years of Fear", "the-exorcist-legacy.png", "The Exorcist Legacy: 50 Years of Fear", 10 },
                    { new Guid("378d7e8a-eb6c-41b0-8bb6-30d62a584660"), true, "lights", "Brenna Thummler", true, "Following Brenna Thummler’s bestselling and critically acclaimed graphic novels Sheets and Delicates, Marjorie, Eliza, and Wendell the ghost are back to uncover the secrets of Wendell’s human life in the third and final heartwarming installment of the Sheets trilogy.", "Lights", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8631), 20, false, "Lights", "Lights", 20f, 20f, "Lights", "lights.png", "Lights", 10 },
                    { new Guid("57c8221a-b39d-4c15-a6ae-829c9bd7abb2"), true, "the-art-of-scandal", "Regina Black", false, "On the night of her husband Matt’s fortieth birthday, Rachel Abbott receives a sexy, explicit text from her husband that she quickly realizes was meant for another woman. Divorce is inevitable, and Rachel is determined not to leave her thirteen-year marriage empty handed. Meanwhile, Matt, a rising star mayor with his eye on the White House, can’t afford a messy split in the middle of his reelection campaign. They strike a deal: Rachel gets one million dollars and their lavish house in the wealthy DC suburb of Oasis Springs, as long as she keeps playing the ideal Black trophy wife until the election.", "The Art of Scandal", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8696), 20, true, "The Art of Scandal", "The Art of Scandal", 20f, 14f, "The Art of Scandal", "the-art-of-scandal.png", "The Art of Scandal", 10 },
                    { new Guid("5d15dd48-580b-4fdd-af71-c1f93ecba693"), true, "together-we-rot", "Skyla Arndt", true, "A teen girl looking for the truth about her missing mother forms a reluctant alliance with her former best friend...in exchange for hiding him from his cult-leading family.", "Together We Rot", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8703), 20, false, "Together We Rot", "Together We Rot", 20f, 14f, "Together We Rot", "together-we-rot.png", "Together We Rot", 10 },
                    { new Guid("719b3c73-4ad0-49bd-9b76-ef2d685b58fc"), true, "things-in-the-basement", "Ben Hatke", true, "From New York Times bestselling author Ben Hatke comes Things in the Basement , a young readers graphic novel about Milo, a young boy who discovers a portal to a secret world in his basement.", "Things in the Basement", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8669), 20, false, "Things in the Basement", "Things in the Basement", 15f, 10f, "Things in the Basement", "things-in-the-basement.png", "Things in the Basement", 10 },
                    { new Guid("7247e58e-3ea6-46f6-8970-cfd42485cabb"), true, "two-minutes-with-the-devil", "Matt Micheli", true, "It’s the summer of 86, and school is out in the little Gulf Coast town of Harbor Bluff. Maximum Overdrive is at the cinema, Rampage is all the rage at the arcade, and the only rule from parents is to be home in time for supper. Things couldn’t be simpler or better . . . until kids begin disappearing while playing a children’s game called Two Minutes with the Devil.", "Two Minutes with the Devil", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8666), 20, false, "Two Minutes with the Devil", "Two Minutes with the Devil", 13f, 8f, "Two Minutes with the Devil", "two-minutes-with-the-devil.png", "Two Minutes with the Devil", 10 },
                    { new Guid("7b58edc8-fbc9-4801-846b-8a2d38ec824c"), true, "the-handyman-method", "Nick Cutter", false, "When a young family moves into an unfinished development community, cracks begin to emerge in both their new residence and their lives, as a mysterious online DIY instructor delivers dark subliminal suggestions about how to handle any problem around the house. The trials of home improvement, destructive insecurities, and haunted house horror all collide in this thrilling story perfect for fans of Nick Cutter’s bestsellers The Troop and The Deep", "The Handyman Method", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8635), 20, true, "The Handyman Method", "The Handyman Method", 25f, 20f, "The Handyman Method", "thehandymanmethod.png", "The Handyman Method", 10 },
                    { new Guid("939c1c71-99b8-4b04-8297-e43e48088144"), true, "a-guest-in-the-house", "Emily Carroll", true, "In Emily Carroll's haunting adult graphic novel horror story A Guest in the House , a young woman marries a kind dentist only to realize that there’s a dark mystery surrounding his former wife’s death.", "A Guest in the House", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8617), 20, false, "A Guest in the House", "A Guest in the House", 20f, 15f, "A Guest in the House", "aguestinthehouse.png", "A Guest in the House", 10 },
                    { new Guid("99ab3ebe-5be5-4d5c-8a0c-0f0c0fd58409"), true, "the-last-girls-standing", "Jennifer Dugan", true, "In this queer YA psychological thriller from the author of Some Girls Do, perfect for fans of One of Us Is Lying and A Good Girl’s Guide to Murder, the sole surviving counselors of a summer camp massacre search to uncover the truth of what happened that fateful night, but what they find out might just get them killed.", "The Last Girls Standing", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8638), 20, false, "The Last Girls Standing", "The Last Girls Standing", 19f, 14f, "The Last Girls Standing", "the-last-girls-standing.png", "The Last Girls Standing", 10 },
                    { new Guid("9f7b257b-b452-468a-9ddb-29a2c44b9933"), true, "omen-of-ice", "Jus Accardo", false, "Keltania Tunne has spent her whole life training to become a bodyguard for a Winter Fae. It’s the highest of honors for a druid…only when Tania arrives at the Winter Court for the first time, nothing is what she expected.", "Omen of Ice", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8724), 20, false, "Omen of Ice", "Omen of Ice", 20f, 14f, "Omen of Ice", "omen-of-ice.png", "Omen of Ice", 10 },
                    { new Guid("a89204be-43fc-47cb-b626-19e2c7d41430"), true, "multitude-of-dreams", "Mara Rutherford", true, "Princess Imogen of Goslind has lived a sheltered life for three years at the boarded-up castle—she and the rest of its inhabitants safe from the bloody mori roja plague that’s ravaged the kingdom. But Princess Imogen has a secret, and as King Stuart descends further into madness, it’s at great risk of being revealed. Rations dwindle each day, and unhappy murmurings threaten to crack the facade of the years-long charade being played within the castle walls.", "A Multitude of Dreams", new Guid("fa50393e-b832-45ed-987a-c61e494effa7"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8642), 20, true, "A Multitude of Dreams", "A Multitude of Dreams", 15f, 10f, "A Multitude of Dreams", "multitude-of-dreams.png", "A Multitude of Dreams", 10 },
                    { new Guid("a9a176bb-f43d-4732-8337-a9110fd41d71"), true, "the-roommate-pact", "Allison Ashley", false, "The proposition is simple: if ER nurse Claire Harper and her roommate, firefighter Graham Scott, are still single by the time they’re forty, they’ll take the proverbial plunge together…as friends with benefits. Maybe it’s the wine, but in the moment, Claire figures the pact is a safe-enough deal, considering she hasn’t had much luck in love and he’s in no rush to settle down. Like, at all. Besides, there’s no way she could ever really fall for Graham and his thrill-seeking ways. Not after what happened to her father…", "The Roommate Pact", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8707), 20, true, "The Roommate Pact", "The Roommate Pact", 20f, 14f, "The Roommate Pact", "the-roommate-pact.png", "The Roommate Pact", 10 },
                    { new Guid("a9c21570-55d0-46f9-96c5-1963d39a5895"), true, "billie-blaster-and-the-robot-armu-from-outer-space", "Laini Taylor", false, "An out-of-this-world new middle-grade graphic novel about a genius scientist and her evil nemesis—from New York Times bestselling author Laini Taylor and cartoonist Jim Di Bartolo", "Billie Blaster and the Robot Army from Outer Space", new Guid("83918000-7c93-435d-aab5-e3177f8e6c81"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8673), 20, true, "Billie Blaster and the Robot Army from Outer Space", "Billie Blaster and the Robot Army from Outer Space", 15f, 10f, "Billie Blaster and the Robot Army from Outer Space", "billie-blaster.png", "Billie Blaster and the Robot Army from Outer Space", 10 },
                    { new Guid("c2d996da-4f24-4d00-aada-8ebf24ff8235"), true, "who-we-are-now", "Lauryn Chamberlain", true, "Four friends. Fifteen years. Who We Are Now is a story of Sliding Doors moments, those seemingly small choices of early adulthood that determine the course of our lives.", "Who We Are Now", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8692), 20, true, "Who We Are Now", "Who We Are Now", 15f, 12f, "Who We Are Now", "who-we-are-now.png", "Who We Are Now", 10 },
                    { new Guid("c8f630ac-68e4-4745-90a7-625873ce88ef"), true, "the-peach-seed", "Anita Gail Jones", false, "Fletcher Dukes and Altovise Benson reunite after decades apart― and a mountain of secrets―in this debut exploring the repercussions of a single choice and how an enduring talisman challenges and holds a family together.", "The Peach Seed", new Guid("79992a22-2a2b-49bc-81a7-66b41ed033b0"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8683), 20, true, "The Peach Seed", "The Peach Seed", 20f, 15f, "The Peach Seed", "the-peach-seed.png", "The Peach Seed", 10 },
                    { new Guid("ca675aac-35fc-4d19-b90e-b0ce326db7a0"), true, "a-little-like-walking", "Adam Rex", false, "You’ve Reached Sam meets The Good Place in this deeply-felt, surreal and fully illustrated love story about a girl, a boy, a dreamer, and a dream from best-selling and award-winning author Adam Rex.", "A Little Like Waking", new Guid("e357abbd-cc3e-4769-9863-9f8b640073f8"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8700), 20, true, "A Little Like Waking", "A Little Like Waking", 20f, 14f, "A Little Like Waking", "a-little-like-waking.png", "A Little Like Waking", 10 },
                    { new Guid("e8a1be77-b3a2-46ed-ae9d-8a92a64cd75c"), true, "in-charm-way", "Lana Harper", false, "A witch struggling to regain what she has lost casts a forbidden spell—only to discover much more than she expected, in this enchanting new rom-com by New York Times bestselling author Lana Harper.", "In Charm's Way", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8714), 20, true, "In Charm's Way", "In Charm's Way", 20f, 14f, "In Charm's Way", "in-charm-way.png", "In Charm's Way", 10 },
                    { new Guid("ef75e8c9-dab2-46ab-b330-e302db4c01e5"), true, "the-apology", "Jimin Han", true, "In South Korea, a 105-year-old woman receives a letter. Ten days later, she has been thrust into the afterlife, fighting to head off a curse that will otherwise devastate generations to come.", "The Apology", new Guid("5c5f3888-d5c2-442c-b05f-b05648370fe9"), new DateTime(2023, 11, 8, 20, 49, 49, 685, DateTimeKind.Local).AddTicks(8720), 20, false, "The Apology", "The Apology", 20f, 14f, "The Apology", "the-apology.png", "The Apology", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LocationId",
                table: "Accounts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

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
                name: "IX_Posts_AccountModelAccountId",
                table: "Posts",
                column: "AccountModelAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TransactStatus");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
