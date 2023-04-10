using System;

namespace DomainModel
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public int AssignedTo { get; set; }
        public int IsComplete { get; set; }

    }
}
