    var app = new Vue({
        el: '#app',
        data: {
            todoList: [],
            searchParam: {
                sortBy: '-',
                sortType: '-'
            },
            isChanged: false,
            newTodo: {
                todo: '',
                priority: null,
                finisDate: null
            },
            updateTodo: {
                Id: null,
                Todo: '',
                PriorityId: null,
                FinishDate: null
            }
        },
        methods: {
            getData() {
                var self = this;
                $.ajax({
                    url: "/Home/GetAllTodo?SortBy=" + self.searchParam.sortBy + "&SortType=" + self.searchParam.sortType,
                    type: "GET",
                    contentType: "application/json",
                    dataType: "JSON",
                    success: function (result) {
                        self.todoList = [];
                        for (var i = 0; i < result.length; i++) {
                            var createdDate = new Date(result[i].createdDate);
                            var finishDate = new Date(result[i].finishDate);
                            result[i].createdDate = createdDate.toLocaleDateString();
                            result[i].finishDate = finishDate.toLocaleDateString();
                            var today = new Date();

                            //check whether todo's due date today
                            result[i]['isTodayDueDate'] = (result[i].finishDate == today.toLocaleDateString() && result[i].isDone == false);

                            //check whether todo's due date overdue
                            result[i]['isOverDueDate'] = (result[i].finishDate < today.toLocaleDateString() && result[i].isDone == false);
                            self.todoList.push(result[i]);

                        }
                    }
                })
            },
            updateTodoChecklistOnly(item) {
                var self = this;
                $.ajax({
                    url: "/Home/UpdateTodo",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify({
                        Id: item.id,
                        IsDone: item.isDone
                    }),
                    dataType: "JSON",
                    success: function (result) {
                        self.isChanged = !self.isChanged;
                    }
                })
            },
            updateData(item) {
                var self = this;
                $.ajax({
                    url: "/Home/GetDataById?Id=" + item.id,
                    type: "GET",
                    contentType: "application/json",
                    dataType: "JSON",
                    success: function (result) {
                        self.updateTodo.Todo = result.todo;
                        self.updateTodo.PriorityId = result.priorityId;
                        self.updateTodo.FinishDate = new Date(result.finishDate);
                    }
                })
            },
            deleteItem(id) {
                var self = this;
                $.ajax({
                    url: "/Home/DeleteById?Id=" + id,
                    type: "DELETE",
                    contentType: "application/json",
                    dataType: "JSON",
                    success: function (result) {
                        self.isChanged = !self.isChanged;
                    }
                })

            },
        },
        watch: {
            isChanged() {
                this.getData();
            }
            }
    })
app.getData();
