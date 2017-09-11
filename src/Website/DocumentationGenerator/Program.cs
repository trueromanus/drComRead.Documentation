using System;
using System.Linq;
using System.IO;
using Markdig;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DocumentationGenerator {

	/// <summary>
	/// This program execute generate program documentation from github website.
	/// </summary>
	class Program {

		/// <summary>
		/// Embed all images.
		/// </summary>
		/// <param name="directory">Directory.</param>
		/// <param name="content">Content.</param>
		static string EmbedAllImages ( string directory , string content ) {
			var result = content;
			var regexp = new Regex ( "img src=\"[a-z\\.]{0,}\"" );
			var mathes = regexp.Matches ( content ).OfType<Match> ();
			foreach ( var match in mathes ) {
				var imagePath = match.Value.Replace ( "img src=" , "" ).Replace ( "\"" , "" );
				var bytes = File.ReadAllBytes ( Path.Combine ( directory , imagePath ) );
				result = result.Replace ( match.Value , $"img src=\"data:image/jpeg; base64, {Convert.ToBase64String ( bytes )}\"" );
			}
			return result;
		}

		/// <summary>
		/// Change references.
		/// </summary>
		/// <param name="content">Content.</param>
		/// <param name="directory">Directory.</param>
		static string ChangeReferences ( string directory , string content ) {
			var result = content;
			var regexp = new Regex ( "a href=\"[a-z\\.]{0,}\"" );
			var mathes = regexp.Matches ( content ).OfType<Match> ();
			foreach ( var match in mathes ) {
				//TODO: get rid this ballshit
				var page = match.Value.Replace ( "a href=\"" , "" ).Replace ( "\"" , "" ).Replace ( ".md" , "" );
				result = result.Replace ( match.Value , $"a href=\"/documentation/russian?part={directory.ToLowerInvariant ()}&page={page}\"" );
			}
			return result;
		}

		/// <summary>
		/// Entry point.
		/// </summary>
		static void Main ( string[] args ) {
			var metaData = new List<string> ();
			var directories = Directory.EnumerateDirectories ( "data" );
			if ( Directory.Exists ( "result" ) ) Directory.Delete ( "result" , recursive: true );

			foreach ( var directory in directories ) {
				var directoryName = directory.Replace ( "data\\" , "" );
				if ( !Directory.Exists ( $"result\\{directoryName}" ) ) Directory.CreateDirectory ( $"result\\{directoryName}" );

				foreach ( var file in Directory.EnumerateFiles ( directory ) ) {
					if ( Path.GetFileName ( file ) == "meta.json" ) {
						metaData.Add ( File.ReadAllText ( file ) );
					}
					if ( Path.GetExtension ( file ) != ".md" ) continue;

					var embeddedImagesContent = EmbedAllImages ( directory , Markdown.ToHtml ( File.ReadAllText ( file ) ) );
					var content = ChangeReferences ( directoryName , embeddedImagesContent );

					File.WriteAllText ( $"result\\{directoryName}\\{Path.GetFileNameWithoutExtension ( file )}.html" , content );
				}
			}

			File.WriteAllText ( $"result\\metadata.json" , $"[{string.Join ( "," , metaData )}]" );
		}

	}

}