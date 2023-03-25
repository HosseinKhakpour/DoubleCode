﻿namespace DoubleCode.Application.Common.Utilities.Security;

public interface ISecurityService
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string password);
    string EncryptText(string input, string password = null);
    string DecryptText(string input, string password = null);
}
