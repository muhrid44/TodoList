$(document).ready(function () {
    var Id = idKu;
    var app = new Vue({
        el: '#app',
        data: {
            todoList: [],
            isChanged: false,
            updateTodo: {
                Id: null,
                Todo: '',
                PriorityId: null,
                FinishDate: null
            }
        },
        methods: {
            getDataById(id) {
                var self = this;
                $.ajax({
                    url: "/Home/GetDataById?Id=" + id,
                    type: "GET",
                    contentType: "application/json",
                    dataType: "JSON",
                    success: function (result) {
                        self.updateTodo.Todo = result.todo;
                        self.updateTodo.PriorityId = result.priorityId;
                        var date = new Date(result.finishDate);
                        var options = { year: 'numeric', month: '2-digit', day: '2-digit'};
                        var shortDate = date.toLocaleDateString(undefined, options);
                        var parts = shortDate.split('/');
                        var formattedInputDate = parts[2] + '-' + parts[0] + '-' + parts[1];
                        self.updateTodo.FinishDate = formattedInputDate;

                    }
                })
            },
            updateData() {
                var self = this;
                var dataSubmitted = {
                    Id: Id,
                    Todo: self.updateTodo.Todo,
                    PriorityId: +self.updateTodo.PriorityId,
                    FinishDate: new Date(self.updateTodo.FinishDate)
                }
                $.ajax({
                    url: "/Home/UpdateTodoAll",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(dataSubmitted),
                    dataType: "JSON",
                    success: function () {
                        window.location = "/Home/Index";
                    }
                })

            }


        }
    })
    app.getDataById(Id);
    app.data.updateTodo.Id = Id;

})