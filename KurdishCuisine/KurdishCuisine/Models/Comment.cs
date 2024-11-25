using System;
using System.Collections.Generic;
namespace KurdishCuisine.Models
{
    public class Comment
    {
        // Comment Id
        public int CommentId { get; set; }

        // Comment the post
        public Post Post { get; set; }

        // User who's commenting
        public User User { get; set; }

        // The comment text
        public string Text { get; set; }

        // Publish date
        public DateTime Date { get; set; }

        // Replies to the comment
        public List<Comment> Replies { get; set; }

        // Parent comment ID for nested comments (optional)
        public int? ParentCommentId { get; set; }

        // Constructor to initialize Replies list
        public Comment()
        {
            Replies = new List<Comment>();
        }

        // Optional: Track if the comment was edited and when
        public DateTime? UpdatedDate { get; set; }
        public bool IsEdited { get; set; }
    }
}
