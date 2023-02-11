const inputs = document.querySelectorAll(".form__input");
/*=== Add focus ===*/
function addfocus() {
	let parent = this.parentNode.parentNode
	parent.classList.add("focus")
}

/*=== Remove focus ===*/
function remfocus() {
	let parent = this.parentNode.parentNode
	if (this.value == "") {
		parent.classList.remove("focus")
	}
}

/*=== To call function===*/
inputs.forEach(input => {
	input.addEventListener("focus", addfocus)
	input.addEventListener("blur", remfocus)
})




const sendData = async (data) => {
	let url = "/Admin/Login/Index";
	await axios.post(url, data).then(res => {

		if (res.data !== true) {
			document.querySelector("#username-input").value = "";
			document.querySelector("#password-input").value = "";
			alert("Tài khoảng hoặc mật khẩu không chính xác")
		} else {
			window.location.href = "/admin";
		}
	});
}
$("#btnLogin").on('click',function(e) {
	let username = document.querySelector("#username-input").value;
	let password = document.querySelector("#password-input").value;
	let supperadmin = document.querySelector("#supperadmin");
	let rememberTag = document.querySelector("#remember");
	let isSupper = supperadmin.checked ? true : false;
	let remember = rememberTag.checked ? true : false;
	var data = {
		username: username,
		password: password,
		isSupper: isSupper,
		RememberMe: remember
	}
	console.log(data);
	sendData(data);
});

