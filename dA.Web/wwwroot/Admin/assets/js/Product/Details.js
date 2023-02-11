// lấy chi tiết của sản phẩm
const getParameterUrl = (url) => {
	var params = {};
	var parser = document.createElement('a');
	parser.href = url;
	var query = parser.search.substring(1);
	var vars = query.split('&');
	for (var i = 0; i < vars.length; i++) {
		var pair = vars[i].split('=');
		params[pair[0]] = decodeURIComponent(pair[1]);
	}
	return params;
}
$(function () {
	GetDataDetail();
})
function formatVND(money) {
	var y = Intl.NumberFormat('vi-VN', { maximumSignificantDigits: 3 });
	return y.format(money)
};
const GetDataDetail = () => {
	var form = $("#ProductFormDetails");
	
	var id = getParameterUrl(window.location.href).id;
	$.get("/Admin/Product/GetOneDetail", { id: id }, function (data) {
		form.find("#Id").val(data.id);
		//form.find("#Name").val(data.name);
		form.find("#Name").text(data.name);
		form.find("#CategoryId").val(data.category);
		form.find("#TrademarkId").val(data.trademark);
		form.find("#Price").text(formatVND(data.price) + "VND");
		form.find("#PromoPrice").text(data.promoPrice);
		form.find("#Description").text(data.description);

		if (data.promoPrice) {
			form.find("#PromoPrice").text(formatVND(data.promoPrice) + "VND");
		}
		else {
			form.find("#PromoPrice").text("Sản phẩm chưa có khuyến mãi");
		}

		if (data.isTopProducts) {
			form.find("#IsTopProducts").attr("checked", "checked");
		}
		if (data.category) {
			form.find("#CategoryId").val(data.category);
		}

		form.find("#CategoryId").val(data.category == null ? "Chưa có thể loại" : data.category.name);

		if (data.description) {
			form.find("#Description").text(data.description);
		}
		else {
			form.find("#Description").text("Chưa có mô tả")
		}
		
	});
	$.get("/Admin/Product/GetImgDetail", { id: id }, function (data) {
		var carousel = $(".carousel-inner")
		data.forEach(function (res, index) {
			if (index == 0) {
				var carouselElm = `<div class="carousel-item active">
										<img src="/Images/Product/${res.name}" class="d-block w-100" alt="...">
								</div> `
				$(carouselElm).appendTo(carousel);
			}
			else {
				var carouselElm = `<div class="carousel-item">
										<img src="/Images/Product/${res.name}" class="d-block w-100" alt="...">
								</div> `
				$(carouselElm).appendTo(carousel);
			}
		});

	});

}
