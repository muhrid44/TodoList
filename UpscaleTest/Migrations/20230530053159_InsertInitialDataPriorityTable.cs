using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpscaleTest.Migrations
{
    /// <inheritdoc />
    public partial class InsertInitialDataPriorityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [PriorityTable] (Priority) " +
                "VALUES ('Not Urgent'), ('Normal'), ('Urgent')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
