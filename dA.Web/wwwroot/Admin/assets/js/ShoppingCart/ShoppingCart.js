function setCookie(cname, cvalue, exdays) {
	var d = new Date();
	d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
	var expires = "expires=" + d.toUTCString();
	document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}


var item = 0;
function SetSize(ev) {
	item = ev.currentTarget;
	return item.value;
};

$(document).on("click", ".values-item", SetSize);
$('.btn.add-shopping-cart').click(function (ev) {
	ev.preventDefault();
	if (item.value === undefined) {
		item = 1;
	}
	var idProduct = $(ev.currentTarget).attr("data-id");
	setCookie("ProductP_" + idProduct, item.value, 10);
	Swal.fire({
		position: 'center',
		icon: 'success',
		title: 'Thêm sản phẩm thành công',
		showConfirmButton: false,
		timer: 2000
	})
});





