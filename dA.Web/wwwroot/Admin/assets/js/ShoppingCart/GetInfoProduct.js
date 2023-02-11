
$(document).ready(function () {

	$(".list-size").focus("click", function (ev) {		
			GetListSize(ev);
			function GetListSize(ev) {
				var id = $(ev.currentTarget).closest("select").attr("data-id");
				$.ajax({
					type: 'GET',
					url: '/SanPham/GetSize',
					data: { id: id },
					success: function (res) {
						$(ev.currentTarget).html('');
						render(res);
					}
				})
			};
			function render(data) {
				var select = $(ev.currentTarget);
				return data.forEach(function (res, index) {
					var options = `
						<option value="${res.id}">${res.name}</option>
						`;
					$(options).appendTo(select);

				});
			};
		});
	$(".list-size").change(function (ev) {
		var idProduct = $(ev.currentTarget).closest("select").attr("data-id");
		var valueSize = document.querySelector(".list-size");
		var value = valueSize.options[valueSize.selectedIndex].value;
		setCookie("ProductP_" + idProduct, value, 10)
	});


	$(".list-quantity").focus(function (ev) {
		
		
		$(".list-quantity").change(function (ev) {
			SumMoney();
			var idProduct = $(ev.currentTarget).closest("select").attr("data-id");
			//var valueQuanlity = document.querySelector(".list-quantity");
			var valueQuanlity = ev.currentTarget;
			var value = valueQuanlity.options[valueQuanlity.selectedIndex].value;
			console.log(valueQuanlity)
			setCookie("ProductSize_" + idProduct, value, 10);
		});
	});

	
});
// js remove product khổi giỏ hàng
$(document).on('click', '.removeCart', function (ev) {
	ev.preventDefault();
	var father = ev.currentTarget.parentElement.parentElement.parentElement;
	father.remove();
	var idbook = ev.currentTarget.getAttribute("data-id");
	setCookie("ProductP_" + idbook, 0, -1);
	setCookie("ProductSize_" + idbook, 0, -1);

	CheckNull();
	SumMoney();
	Swal.fire({
		position: 'center',
		icon: 'success',
		title: 'Thao tác thành công',
		showConfirmButton: false,
		timer: 1500
	})

});


// js tính tiền 
function SumMoney() {
	var vnd = Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' });
	var sumMoney = 0;
	var itemMoney = document.querySelectorAll(".Money-item");
	var itemQuantitys = document.querySelectorAll(".list-quantity");

	for (var i = 0; i < itemMoney.length; i++) {
		var itemQuantity = itemQuantitys[i].options[itemQuantitys[i].selectedIndex].text;
		sumMoney += parseFloat(itemMoney[i].getAttribute("data-price") * itemQuantity);
		var tmp = parseFloat(itemMoney[i].getAttribute("data-price") * itemQuantity);
		itemMoney[i].innerHTML = vnd.format(tmp);
	}

	var total = sumMoney + 35000; // + 35K phi ship

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
	CheckNull();
	SumMoney();
})

function CheckNull() {
	var checkCookie = document.cookie;
	if (checkCookie == "") {
		var btnElm = document.querySelectorAll('a.btn')
		for (var i = 0; i < btnElm.length; i++) {
			btnElm[i].classList.add("disabled");
		}
		var tongTienEle = document.querySelector('.SumMoneyProduct');
		var tamTinhEle = document.querySelector('.TmpSumMoneyProduct');
		var priceShipEle = document.querySelector('.priceShip');
		tamTinhEle.innerHTML = "0 đ";
		tongTienEle.innerHTML = "0 đ";
		priceShipEle.innerHTML = "0 đ";

		var eleShopRight = document.querySelector(".shoppingcart_left");
		eleShopRight.append("Chưa có sản phẩm nào cho giỏ hàng của bạn")
	}
}