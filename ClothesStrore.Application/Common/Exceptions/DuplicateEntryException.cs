﻿namespace ClothesStrore.Application.Common.Exceptions;

public class DuplicateEntryException : Exception
{
    public DuplicateEntryException(string message) : base(message)
    {

    }
}
