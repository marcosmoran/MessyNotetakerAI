namespace MessyNotetaker.Api.Dtos;

public record class UpdateNoteDto(
    string Title, 
    string Tag, 
    string MessyNote, 
    string FormattedNote,
    DateTime TimeCreated,
    DateTime TimeUpdated);