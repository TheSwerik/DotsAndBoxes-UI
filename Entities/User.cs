﻿using System;

namespace UI.Entities
{
    [Serializable]
    public struct User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public override string ToString() { return $"{{ ID: {Id} | Username: {Username} }}"; }
    }
}