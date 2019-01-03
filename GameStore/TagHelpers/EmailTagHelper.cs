using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GameStore.TagHelpers
{
	/// <summary>
	/// Custom tag helper
	/// </summary>
	public class EmailTagHelper : TagHelper
	{
		/// <summary>
		/// Current email address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// All content
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Set custom helper output
		/// </summary>
		/// <param name="output">Helper output</param>
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			// output tag a
			output.TagName = "a";

			// use current address
			output.Attributes.SetAttribute("href", "mailto:" + Address);

			// set all available content
			output.Content.SetContent(Content);
		}
	}
}
