// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(() => {
    $("#search-field").change(() => {
        var link = $("#search-field").next().attr("href");
        var textBoxValue = $("#search-field").val();
        link = link.split('?')[0];
        $("#search-field").next().attr("href", `${link}?pattern=${textBoxValue}`);
    })
})