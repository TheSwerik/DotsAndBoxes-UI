using System;

namespace UI.Entities
{
    public struct User
    {
        public Guid Id;
        public string Username;
        public override string ToString() { return $"{{ ID: {Id} | Username: {Username} }}"; }
    }
}