var check_name = /^[A-Za-z0-9 ]{3,20}$/;
var check_email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i ;
var check_password =  /^[A-Za-z0-9!@#$%^&*()_]{6,20}$/;

function validate(){
var name = document.getElementById('username').value;
var email = document.getElementById('email').value;
var password = document.getElementById('password').value;
var errors = [];

 if (!check_name.test(name)) {
  errors[errors.length] = "You valid Name (3-20).";
 }
 if (!check_email.test(email)) {
  errors[errors.length] = "You must enter a valid email address.";
 }
 if (!check_password.test(password)) {
  errors[errors.length] = "You must enter a valid Password (6-20).";
}
 if (errors.length > 0) {
  reportErrors(errors);
  return false;
 }
  return true;
}
function reportErrors(errors){
 var msg = "Please Enter Valide Data...\n";
 for (var i = 0; i<errors.length; i++) {
 var numError = i + 1;
  msg += "\n" + numError + ". " + errors[i];
}
 alert(msg);
}
