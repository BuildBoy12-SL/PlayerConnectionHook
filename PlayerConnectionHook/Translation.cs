// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace PlayerConnectionHook
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets the image in the title of the embed.
        /// </summary>
        [Description("The image in the title of the embed.")]
        public string TitleImage { get; set; } = "https://i.imgur.com/fuKILwb.jpeg";

        /// <summary>
        /// Gets or sets the title of the embed when a player joins.
        /// </summary>
        [Description("The title of the embed when a player joins.")]
        public string PlayerJoinedTitle { get; set; } = "Player Joined";

        /// <summary>
        /// Gets or sets the message to use when a player joins.
        /// Arguments: {0} - Player Name, {1} - Server Name, {2} - Port, {3} - Current Players, {4} - Max Players.
        /// </summary>
        [Description("Gets or sets the message to use when a player joins. Arguments: {0} - Player Name, {1} - Server Name, {2} - Port, {3} - Current Players, {4} - Max Players")]
        public string PlayerJoined { get; set; } = "{0} has joined {1}!\nCurrent Players: {3}/{4}";

        /// <summary>
        /// Gets or sets the title of the embed when a player leaves.
        /// </summary>
        [Description("The title of the embed when a player leaves.")]
        public string PlayerLeftTitle { get; set; } = "Player Left";

        /// <summary>
        /// Gets or sets the message to use when a player leaves.
        /// Arguments: {0} - Player Name, {1} - Server Name, {2} - Port, {3} - Current Players, {4} - Max Players.
        /// </summary>
        [Description("Gets or sets the message to use when a player leaves. Arguments: {0} - Player Name, {1} - Server Name, {2} - Port, {3} - Current Players, {4} - Max Players")]
        public string PlayerLeft { get; set; } = "{0} has left {1}!\nCurrent Players: {3}/{4}";

        /// <summary>
        /// Gets or sets the footer of the embed.
        /// </summary>
        public string EmbedFooter { get; set; }
    }
}