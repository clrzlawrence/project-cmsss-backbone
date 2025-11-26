using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProjectCms.Models
{
    public class ArchivedPage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        // original page id
        [BsonElement("pageId")]
        public string PageId { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("slug")]
        public string Slug { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("content")]
        public string Content { get; set; } = string.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = string.Empty; // draft / published

        [BsonElement("featuredImage")]
        public string FeaturedImage { get; set; } = string.Empty;

        [BsonElement("tags")]
        public List<string> Tags { get; set; } = new();

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("publishDate")]
        public DateTime? PublishDate { get; set; }

        [BsonElement("author")]
        public string Author { get; set; } = string.Empty;

        // "Deleted" or future "Expired"
        [BsonElement("archiveType")]
        public string ArchiveType { get; set; } = "Deleted";

        [BsonElement("archivedAt")]
        public DateTime ArchivedAt { get; set; } = DateTime.UtcNow;
    }
}
