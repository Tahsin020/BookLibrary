﻿namespace BookLibrary.Web.Dtos;

public class ResultBookDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Status { get; set; }
}
