namespace MessyNotetaker.Api.Dtos;

public record class NoteDto(
    int Id,
    string Title, 
    string Tag, 
    string messyNote, 
    string formattedNote,
    DateTime timeCreated,
    DateTime timeUpdated);