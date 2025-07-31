namespace  MessyNotetaker.Api.Endpoints;
using MessyNotetaker.Api.Dtos;

public static class NotesEndpoints
{
    private  readonly List<NoteDto> notes = [
        new NoteDto(
            Id: 1,
            Title: "Grocery List",
            Tag: "Personal",
            MessyNote: "milk,eggs - maybe get bread??",
            FormattedNote: "Milk, eggs. Maybe get bread?",
            TimeCreated: DateTime.Now.AddDays(-2),
            TimeUpdated: DateTime.Now.AddDays(-1)
        ),

        new NoteDto(
            Id: 2,
            Title: "Meeting Notes",
            Tag: "Work",
            MessyNote: "talked about Q3 goals... deadline???, ask sarah",
            FormattedNote: "Talked about Q3 goals. Follow up on deadline. Ask Sarah.",
            TimeCreated: DateTime.Now.AddDays(-1),
            TimeUpdated: DateTime.Now
        ),

        new NoteDto(
            Id: 3,
            Title: "Ideas for App",
            Tag: "Project",
            MessyNote: "note cleaner + ai rewrite - check if blazor good?",
            FormattedNote: "Note cleaner with AI rewriting. Consider using Blazor.",
            TimeCreated: DateTime.Now.AddHours(-6),
            TimeUpdated: DateTime.Now.AddHours(-2)
        )
    ];

public static WebApplication MapNotesEndpoints(this WebApplication app)
{
    app.MapGet("notes", () => notes);
    app.MapGet("notes/{id}", (int id) =>
    {
        NoteDto? note = notes.Find(note => note.Id == id);
        return note is null ? Results.NotFound() : Results.Ok(note);
    
    }).WithName("GetNote");
    app.MapPost("notes", (CreateNoteDto newNote) =>
    {
        NoteDto note = new(
            notes.Count + 1,
            newNote.Title,
            newNote.Tag,
            newNote.MessyNote,
            newNote.FormattedNote,
            newNote.TimeCreated,
            newNote.TimeUpdated
        );
        notes.Add(note);

        return Results.CreatedAtRoute("GetNote", new {id = note.Id}, note);
    });

    app.MapPut("notes/{id}", (int id, UpdateNoteDto newNote) =>
    {
        int index = notes.FindIndex(note => note.Id == id);
        if (index == -1) return Results.NotFound();
        
        notes[index] = new NoteDto(
            notes[index].Id,
            newNote.Title,
            newNote.Tag,
            newNote.MessyNote,
            newNote.FormattedNote,
            newNote.TimeCreated,
            newNote.TimeUpdated
        );
        return Results.NoContent();
    });

    app.MapDelete("notes/{id}" , (int id) =>
    {
        notes.RemoveAll(note => note.Id == id);
        return Results.NoContent();
    });

    return app;
}}
