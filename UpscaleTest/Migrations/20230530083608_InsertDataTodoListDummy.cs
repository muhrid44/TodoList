using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;

#nullable disable

namespace UpscaleTest.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataTodoListDummy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DateTime createdDateToday = DateTime.Today.Date;
            DateTime finishDateToday = DateTime.Today.Date;
            DateTime finishDateYesterday = DateTime.Today.Date.AddDays(-1);
            DateTime finishDateTomorrow = DateTime.Today.Date.AddDays(1);

            //migrationBuilder.Sql("INSERT INTO [TodoTable] ([Todo], [PriorityId], [CreatedDate], [FinishDate], [IsDone]) " +
            //$"VALUES ('Review Task A', 1, {createdDateToday}, {finishDateToday}, 1), " +
            //$"('Review Task B', 2, {createdDateToday}, {finishDateToday}, 0), " +
            //$"('Review Task C', 2, {createdDateToday}, {finishDateYesterday}, 1), " +
            //$"('Review Task D', 3, {createdDateToday}, {finishDateYesterday}, 0), " +
            //$"('Review Task E', 2, {createdDateToday}, {finishDateTomorrow}, 1), " +
            //$"('Review Task E', 1, {createdDateToday}, {finishDateTomorrow}, 0)");

            migrationBuilder.InsertData(
            table: "TodoTable",
                columns: new[] { "Todo", "PriorityId", "CreatedDate", "FinishDate", "IsDone" },
                values: new object[,]
                {
                    { "Review Task A", 1, createdDateToday, finishDateToday, true },
                    { "Review Task B", 2, createdDateToday, finishDateToday, false },
                    { "Review Task C", 2, createdDateToday, finishDateYesterday, true },
                    { "Review Task D", 3, createdDateToday, finishDateYesterday, false },
                    { "Review Task E", 2, createdDateToday, finishDateTomorrow, true },
                    { "Review Task F", 1, createdDateToday, finishDateTomorrow, false },
                }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
