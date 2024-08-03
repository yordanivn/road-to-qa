using System;
using System.ComponentModel.DataAnnotations;
using static MVC_Demo2.Data.DataConstants.Post;

namespace MVC_Demo2.Data.Models
{
	public class Post
	{
		public int Id { get; init; }

		[Required]
		public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;
	}
}

