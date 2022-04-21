// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
jQuery(document).ready(function ($) {
  function comfirmSubmitMessage(e) {
    var answer = confirm('Jeste li sigurni?');

    if (answer) return;

    e.preventDefault();
  }

  $('.btn').on('click.submitButton', comfirmSubmitMessage);
});
