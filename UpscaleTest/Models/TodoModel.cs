using System.ComponentModel.DataAnnotations;

namespace UpscaleTest.Models
{
    public class TodoModel
    {
            public int Id { get; set; }
            public string? Todo { get; set; }
            public int PriorityId { get; set; }
            [Display(Name = "Created Date")]
            public DateTime CreatedDate { get; set; }
            [Display(Name = "Finish Date")]

            public DateTime FinishDate { get; set; }
            [Display(Name = "Done")]
            public bool IsDone { get; set; }

            public PriorityModel? PriorityModel { get; set; }
    }
}
