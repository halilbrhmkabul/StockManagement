using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Data.Migrations
{
    public partial class AddDataToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("Insert Into Currencies (Name, Symbol, Description, Status) Values ('Türk Lirası', '₺', 'Açıklama','True')");
            //migrationBuilder.Sql("Insert Into Currencies (Name, Symbol, Description, Status) Values ('Amerikan Doları', '$', 'Açıklama','True')");
            //migrationBuilder.Sql("Insert Into Currencies (Name, Symbol, Description, Status) Values ('Euro', '€', 'Açıklama','True')");
            //migrationBuilder.Sql("Insert Into Currencies (Name, Symbol, Description, Status) Values ('Kanada Doları', 'C$', 'Açıklama','True')");

            //migrationBuilder.Sql("INSERT INTO QuantityUnits (Name, Description, Status) VALUES ('Gram', 'Açıklama', true)");
            //migrationBuilder.Sql("INSERT INTO QuantityUnits (Name, Description, Status) VALUES ('Litre', 'Açıklama', true)");
            //migrationBuilder.Sql("INSERT INTO QuantityUnits (Name, Description, Status) VALUES ('m3', 'Açıklama', true)");
            //migrationBuilder.Sql("INSERT INTO QuantityUnits (Name, Description, Status) VALUES ('Adet', 'Açıklama', true)");
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
