var app = new Vue({
    el: '#app',
    data: {
        todoList: [],
        isChanged: false,
        newTodo: {
            Todo: '',
            PriorityId: null,
            FinisDate: null
        }
    },
    methods: {
        postData() {
            var self = this;
            var dataSubmitted = {
                Todo: self.newTodo.Todo,
                PriorityId: +self.newTodo.PriorityId,
                FinishDate: new Date(self.newTodo.FinisDate),
                IsDone: false
                }
            $.ajax({
                url: "/Home/CreateTodo",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(dataSubmitted),
                dataType: "JSON",
                success: function () {
                    self.newTodo.todo = '';
                    self.newTodo.priorityId = null;
                    self.newTodo.finishDate = null;
                    window.location = "/Home/Index";
                }
            })
        },
        updateData() {
            var self = this;
            var dataSubmitted = {
                Todo: self.newTodo.Todo,
                PriorityId: +self.newTodo.PriorityId,
                FinishDate: new Date(self.newTodo.FinisDate)
            }
            $.ajax({
                url: "/Home/UpdateTodo",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(dataSubmitted),
                dataType: "JSON",
                success: function () {
                    self.newTodo.todo = '';
                    self.newTodo.priorityId = null;
                    self.newTodo.finishDate = null;
                    window.location = "/Home/Index";
                }
            })

        }
    }
})