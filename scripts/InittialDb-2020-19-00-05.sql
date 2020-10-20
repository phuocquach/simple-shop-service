CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Brands" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Brands" PRIMARY KEY,
    "CreatedDateUtc" TEXT NOT NULL,
    "UpdatedDateUtc" TEXT NOT NULL,
    "CreatedBy" TEXT NULL,
    "UpdatedBy" TEXT NULL,
    "Name" TEXT NULL,
    "Country" TEXT NULL,
    "IsDeleted" INTEGER NOT NULL
);

CREATE TABLE "Categories" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY,
    "CreatedDateUtc" TEXT NOT NULL,
    "UpdatedDateUtc" TEXT NOT NULL,
    "CreatedBy" TEXT NULL,
    "UpdatedBy" TEXT NULL,
    "Name" TEXT NULL,
    "IsDeleted" INTEGER NOT NULL,
    "IsActive" INTEGER NOT NULL
);

CREATE TABLE "Products" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY,
    "CreatedDateUtc" TEXT NOT NULL,
    "UpdatedDateUtc" TEXT NOT NULL,
    "CreatedBy" TEXT NULL,
    "UpdatedBy" TEXT NULL,
    "Name" TEXT NULL,
    "IsDeleted" INTEGER NOT NULL,
    "IsActive" INTEGER NOT NULL,
    "Price" REAL NOT NULL,
    "InStock" INTEGER NOT NULL,
    "ProductCode" TEXT NULL,
    "BrandId" TEXT NOT NULL,
    CONSTRAINT "FK_Products_Brands_BrandId" FOREIGN KEY ("BrandId") REFERENCES "Brands" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CategoryBrands" (
    "CategoryId" TEXT NOT NULL,
    "BrandId" TEXT NOT NULL,
    CONSTRAINT "PK_CategoryBrands" PRIMARY KEY ("BrandId", "CategoryId"),
    CONSTRAINT "FK_CategoryBrands_Brands_BrandId" FOREIGN KEY ("BrandId") REFERENCES "Brands" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CategoryBrands_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ProductCategories" (
    "ProductId" TEXT NOT NULL,
    "CategoryId" TEXT NOT NULL,
    CONSTRAINT "PK_ProductCategories" PRIMARY KEY ("ProductId", "CategoryId"),
    CONSTRAINT "FK_ProductCategories_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ProductCategories_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ProductImages" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_ProductImages" PRIMARY KEY,
    "OriginalName" TEXT NULL,
    "UsingName" TEXT NULL,
    "StorageUrl" TEXT NULL,
    "IsPrimary" INTEGER NOT NULL,
    "ProductId" TEXT NOT NULL,
    CONSTRAINT "FK_ProductImages_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_CategoryBrands_CategoryId" ON "CategoryBrands" ("CategoryId");

CREATE INDEX "IX_ProductCategories_CategoryId" ON "ProductCategories" ("CategoryId");

CREATE INDEX "IX_ProductImages_ProductId" ON "ProductImages" ("ProductId");

CREATE INDEX "IX_Products_BrandId" ON "Products" ("BrandId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200620144359_initial', '3.1.4');

DROP TABLE "CategoryBrands";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200711081750_updaterelation', '3.1.4');