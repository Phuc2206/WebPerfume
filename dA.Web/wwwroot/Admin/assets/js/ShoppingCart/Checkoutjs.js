var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();
connection.start();

function SumMoney() {
	var sumMoney = 0;
	var itemMoney = document.querySelectorAll(".Money-item");
	var itemQuantitys = document.querySelectorAll(".list-quantity");
	for (var i = 0; i < itemMoney.length; i++) {
		var itemQuantity = itemQuantitys[i].innerText;
		sumMoney += parseFloat(itemMoney[i].getAttribute("data-price") * parseInt(itemQuantity));
	}
	var total = sumMoney + 35000; // + 35K phi ship
	var vnd = Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' });
	const tongTienEle = document.querySelector('.SumMoneyProduct');
	const tamTinhEle = document.querySelector('.TmpSumMoneyProduct');
	const priceShipEle = document.querySelector('.priceShip');
	if (sumMoney > 0 && total > 35000) {
		tamTinhEle.innerHTML = vnd.format(sumMoney)
		tongTienEle.innerHTML = vnd.format(total);
		priceShipEle.innerHTML = vnd.format(35000);
	}

}
$(document).ready(function () {
	SumMoney();
})

function getTextOfSelectedOption(sel) {
	return sel.options[sel.selectedIndex].text;
}

$(".js-checkout").click(function (ev) {
	ev.preventDefault();
	let Email = document.querySelector('#Email').value;
	let Name = document.querySelector('#Name').value;
	let PhoneNumber = document.querySelector('#PhoneNumber').value;
	let StreetAddress = document.querySelector('#StreetAddress').value;
	let provinceTag = document.querySelector('#billingProvince');
	let province = getTextOfSelectedOption(provinceTag);

	let districtTag = document.querySelector('#billingDistrict');
	let district = getTextOfSelectedOption(districtTag);

	let wardTag = document.querySelector('#billingWard');
	let ward = getTextOfSelectedOption(wardTag);
	let GhiChu = document.querySelector('#GhiChu').value;

	var message = "Ban co don hang moi";

	if (Email == "" || Name == "" || PhoneNumber == "" || StreetAddress == "" || provinceTag.value == 0 || districtTag.value == 0 || wardTag.value == 0) {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Vui lòng chọn địa chỉ giao hàng!'
		});
	} else {
		var model = {
			Email: Email,
			Name: Name,
			PhoneNumber: PhoneNumber,
			StreetAddress : StreetAddress,
			ThanhPho: province,
			QuanHuyen: district,
			PhuongXa : ward,
			GhiChu: GhiChu
		};
		$.ajax({
			url: "/Checkout/CheckoutAjax",
			data: model,
			dataType: 'json',
			type: "POST",
			success: function (res) {
				if (res == true) {
					Swal.fire({
						position: 'center',
						icon: 'success',
						title: 'Đặt hàng thành công',
						showConfirmButton: false,
						timer: 1500
					}).then(function () {
						deleteCookieCart();
						window.location.href = "/SanPham/index";
					});
				}
				else {
					Swal.fire({
						icon: 'error',
						title: 'Oops...',
						text: 'Có lỗi xảy ra trong quá trình lưu đơn hàng, vui lòng thử lại sau ít phút!',
						footer: '<a href="#">Báo cáo lỗi này?</a>'
					})
				}
			}
			
		})
	}


});

function setCookie(cname, cvalue, exdays) {
	var d = new Date();
	d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
	var expires = "expires=" + d.toUTCString();
	document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
const deleteCookieCart = () => {
	let cookieList = document.cookie.split(';');
	for (var i = 0; i < cookieList.length; i++) {
		if (cookieList[i].indexOf("ProductP_") > -1 || cookieList[i].indexOf("ProductSize_") > -1) {
			let productId = cookieList[i].split('=')[0];
			setCookie(productId, 0, -1);
			setCookie("ProductSize_" + productId, 0, -1);

		}
	}
}