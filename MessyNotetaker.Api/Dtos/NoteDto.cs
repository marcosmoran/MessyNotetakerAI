namespace MessyNotetaker.Api.Dtos;

public record class NoteDto(
    int Id,
    string Title, 
    string Tag, 
    string MessyNote, 
    string FormattedNote,
    DateTime TimeCreated,
    DateTime TimeUpdated);