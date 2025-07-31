namespace MessyNotetaker.Api.Dtos;

public record class CreateNoteDto(
    string Title, 
    string Tag, 
    string MessyNote, 
    string FormattedNote,
    DateTime TimeCreated,
    DateTime TimeUpdated);