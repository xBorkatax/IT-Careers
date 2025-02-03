// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
	$("nav [href]").each(function () {
		if (this.href.split("?")[0] == window.location.href.split("?")[0]) {
			$(this).addClass("nav-link-active");
		}
	});
});
