namespace Questions.Domain;

public class Question
{
    public Question(
        Guid id,
        string title,
        string text,
        Guid userId,
        Guid? screenshotId,
        IEnumerable<Guid> tags)
    {
        Id = id;
        Title = title;
        Text = text;
        UserId = userId;
        AttachmentId = screenshotId;
        Tags = tags.ToList();
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public Guid UserId { get; set; }

    public Guid? AttachmentId { get; set; }

    public List<Answer> Answers { get; set; } = [];

    public Answer? Solution { get; set; }

    public List<Guid> Tags { get; set; }

    public QuestionStatus Status { get; set; } = QuestionStatus.Open;
}