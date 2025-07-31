using MessyNotetaker.Api.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<NoteDto> notes = [
    new NoteDto(
        Id: 1,
        Title: "Grocery List",
        Tag: "Personal",
        messyNote: "milk,eggs - maybe get bread??",
        formattedNote: "Milk, eggs. Maybe get bread?",
        timeCreated: DateTime.Now.AddDays(-2),
        timeUpdated: DateTime.Now.AddDays(-1)
    ),

    new NoteDto(
        Id: 2,
        Title: "Meeting Notes",
        Tag: "Work",
        messyNote: "talked about Q3 goals... deadline???, ask sarah",
        formattedNote: "Talked about Q3 goals. Follow up on deadline. Ask Sarah.",
        timeCreated: DateTime.Now.AddDays(-1),
        timeUpdated: DateTime.Now
    ),

    new NoteDto(
        Id: 3,
        Title: "Ideas for App",
        Tag: "Project",
        messyNote: "note cleaner + ai rewrite - check if blazor good?",
        formattedNote: "Note cleaner with AI rewriting. Consider using Blazor.",
        timeCreated: DateTime.Now.AddHours(-6),
        timeUpdated: DateTime.Now.AddHours(-2)
    )
];


app.MapGet("/", () => "Messy Notetaker! ");
app.MapGet("notes", () => notes);
app.Run();
