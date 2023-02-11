
// format tien 
function formatVND(money) {
	var y = Intl.NumberFormat('vi-VN', { maximumSignificantDigits: 3 });
	return y.format(money)
};

window.rowCount = 1;
window.sizeCout = 0;
window.quantitySize = 1;
$("#btnAddSize").click(function (ev) {
	var template = $("#js-params-row-template-size");
	var newRow = template.clone();				// sao chép thẻ

	newRow.removeClass('d-none').addClass('js-params-row-size');
	newRow.removeAttr("id");

	var inputOfRow = newRow.find("input");
	inputOfRow.each(function (i, item) {
		var inputName = $(item).attr("name");
		inputName = inputName.replace("{0}", window.rowCount);
		$(item).attr("name", inputName);
		if (i == 0) {
			$(item).val(String(sizeCout));
		}
		if (i == 1) {
			$(item).val(window.quantitySize);
		}
	});
	window.sizeCout += 1;
	window.rowCount += 1;

	// insert thẻ mới vào sau js-params-row cuối cùng
	$(".js-params-row-size").last().after(newRow);
});

// btn an modal
$("#btnClose").on("click", function () {
	$("#Id").val(null);
	$('#Product_modal').modal('hide')
	window.rowCount = 1;
	window.rowCount2 = 1;
	window.sizeCout = 36;
	/*$("#ProductForm")[0].reset();*/
});
// btn lưu modal
$("#btnSaveProduct").on("click", function (ev) {
	ev.preventDefault();

	let Name = document.querySelector('#Name').value;
	let Price = document.querySelector('#Price').value;
	let PromoPrice = document.querySelector('#PromoPrice').value;

	if (Name == "" || parseInt(Price) <= -1 || parseInt(PromoPrice) <= -1) {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Vui lòng nhập đủ thông tin sản phẩm!'
		});
	}
	else {
		var form = $("#ProductForm");
		var data = new FormData(form[0]);
		$.ajax({
			url: "/Admin/Product/Add",
			data: data,
			dataType: 'json',
			type: "POST",
			processData: false,
			contentType: false,
			success: function (res) {
				if (res == true) {
					$('#Product_modal').modal('hide')
					$("#ProductForm")[0].reset();
					Swal.fire({
						position: 'center',
						icon: 'success',
						title: 'Thao tác thành công',
						showConfirmButton: false,
						timer: 1500
					}).then(function () {
						window.location.href = "/Admin/Product/index";
					});
				}
				else {
					Swal.fire({
						position: 'center',
						icon: 'error',
						title: 'Thao tác thất bại',
						showConfirmButton: false,
						timer: 1500
					})
				}
			}
		});
	}
	
})


// lấy list thể loại
const GetCategories = () => {
	$.ajax({
		type: 'GET',
		url: "/Admin/Product/GetCategories",
		success: function (res) {
			$('#CategoryId').html('');
			render(res);
		}
	});

	function render(data) {
		var select = $('#CategoryId');
		select.append("<option>Chọn thể loại</option>");
		return data.forEach(function (res, index) {
			var options = `
							<option value="${res.id}">${res.name}</option>
							`;
			$(options).appendTo(select);
		});
	};
}
$(document).on("click", "#js-GetListCategory", function () {
	GetCategories();
});

// lấy dử liệu lên cho việc Update product ;
$(document).on("click", ".js-update", function (ev) {
	ev.preventDefault();
	var form = $("#ProductForm");
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	$.get("/Admin/Product/GetOneDetail", { id: id }, function (data) {
		console.log(data)
		form.find("#Id").val(data.id);
		form.find("#Name").val(data.name);
		form.find("#Url").val(data.url);
		form.find("#Summary").val(data.summary);
		form.find("#Description").val(data.description);
		form.find("#Quantity").val(data.quantity);
		form.find("#DisplayOrder").val(data.displayOrder);
		form.find("#Price").val(formatVND(data.price));
		form.find("#PromoPrice").val(formatVND(data.promoPrice));

		var options = `<option value=${data.categoryNavigation.id}>${data.categoryNavigation.name}</option>`;
		form.find("#CategoryId").append(options);
		console.log(form.find("#CategoryId"));
	});

	// Gọi lại danh sach thể loại nếu người dùng cần sữa
	$("#CategoryId").focus(function () {
		GetCategories();
	})

	$.get("/Admin/Product/GetImgDetail", { id: id }, function (data) {
		var carousel = $(".dandev_attach_view")
		data.forEach(function (res, index) {
		var carouselElm = `
							<li >
								<div class="img-wrap">
									<span class="close" onclick="DelImg(this)">×</span>
									<div class="img-wrap-box"><img src="/Images/Product/${res.name}"></div>
								</div>
								<div>
								<input type="file" class="hidden" name="ListProductPicture" onchange="uploadImg(this)" ></div>
							</li>
						`
			$(carouselElm).appendTo(carousel);
		});
	});
});


// js-delete 
$(document).on("click", ".js-delete", function (ev) {
	ev.preventDefault();
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	Swal.fire({
		title: 'Bạn có chắc xóa không?',
		text: "Bạn sẽ không thể hoàn nguyên điều này",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#3085d6',
		cancelButtonColor: '#d33',
		confirmButtonText: 'Xóa',
		cancelButtonText: 'Hủy'
	}).then((result) => {
		if (result.isConfirmed) {
			$.ajax({
				type: "DELETE",
				url: "/Admin/Product/Delete",
				data: { id: id },
				success: function (res) {
					if (res == true) {
						Swal.fire({
							position: 'center',
							icon: 'success',
							title: 'Thao tác thành công',
							showConfirmButton: false,
							timer: 1500
						})
						loadData();
					}
					else {
						Swal.fire({
							position: 'center',
							icon: 'error',
							title: 'Thao tác thất bại',
							showConfirmButton: false,
							timer: 1500
						})
						loadData()
					}
				}

			})
		}
	});
	
});


// ajax lay list product
function loadData(_page) {
	$.get({
		type: 'GET',
		url: '/Admin/Product/ListProduct?page=' + _page,
		success: function (res) {
			$('tbody').html('');
			render(res.data);
			var currentPage = res.currentPage;
			var pageSize = res.perPage;
			var totalRow = res.pageCount;
			var arrPager = getPager(currentPage, pageSize, totalRow);
			arrPager = arrPager.map(function (item) {
				var eleClass = "";
				if (item.isCurrentPage) {
					eleClass = "active";
				}
				return (
					'<li><a class="border-radius-0 btn btn-outline-secondary ' +
					eleClass +
					'" data-page="' +
					item.page +
					'" href="#">' +
					item.text +
					"</a></li>"
				);
			});
			var pagination = $(".pagination");
			pagination.html(arrPager.join(""));
		}
	}).then(function () {
		$("a[data-page]").click(function (ev) {
			ev.preventDefault();
			page = $(ev.currentTarget).attr("data-page");
			loadData(page);
		});
	});
};
function render(data) {
	return data.forEach(function (res, index) {
		var tr = $('<tr>').appendTo('tbody');
		var td = `		<td>${res.id}</td>
						<td class="width-150px"><span class="text-truncate ">${res.name}</span></td>
						<td> <img img-fluid rounded-circle img-responsive" style="height:100px ; width:100px;  object-fit:cover;" src="/Images/Product/${res.imgName}"></td>
						<td>${res.sold}</td>
						<td >${formatVND(res.price)} VND</td>
						<td >${res.promoPrice == null ? "0" : formatVND(res.promoPrice)}</td>
						<td>${res.cateName == null ? "Chưa có thể loại" : res.cateName}</td>
						<td data-id="${res.id}">
							<div class="btn-group btn-group-sm" role="group">
								<a class="btn btn-outline-secondary js-detail" data-id="${res.id}" href="/Admin/Product/Details?id=${res.id}">
									<i class="fas fa-eye"></i>
								</a>
								<button class="btn btn-outline-secondary js-update" type="button"  data-id="${res.id}" data-bs-toggle="modal" data-bs-target="#Product_modal">
									<i class="fas fa-edit"></i>
								</button>
								<a hef="#" class="btn btn-outline-secondary js-delete" data-id="${res.id}">
									<i class="fas fa-trash-alt"></i>
								</a>
							</div>
						</td>`
		$(td).appendTo(tr);
	});
}
window.addEventListener('load', () => {
	loadData();
});


/// Function phân trang js
function getPager(currentPage, pageSize, totalRow) {
	const ON_EACH_SIDE = 1;
	var arrPager = [];
	var totalPage = Math.ceil(totalRow / pageSize);

	currentPage = parseInt(currentPage);
	if (totalPage == 0) {
		return arrPager;
	}
	else {
		// current page
		arrPager.push({
			isCurrentPage: true,
			text: currentPage,
			page: currentPage,
		});
		// after current page
		var i = 1;
		while (currentPage + i <= totalPage) {
			arrPager.push({
				isCurrentPage: false,
				text: currentPage + i,
				page: currentPage + i,
			});
			i++;
			if (i > ON_EACH_SIDE) break;
		}
		if (currentPage + ON_EACH_SIDE < totalPage) {
			arrPager.push({
				isCurrentPage: false,
				text: "&rArr;",
				page: totalPage,
			});
		}
		// before current page
		i = 1;
		var tmp = currentPage;
		while (tmp > 1) {
			arrPager.unshift({
				isCurrentPage: false,
				text: currentPage - i,
				page: currentPage - i,
			});
			i++;
			tmp--;
			if (i > ON_EACH_SIDE) break;
		}
		if (currentPage - ON_EACH_SIDE > 1) {
			arrPager.unshift({
				isCurrentPage: false,
				text: "&lArr;",
				page: 1,
			});
		}
	}
	return arrPager;
}


const imageUploadContainer = document.querySelector(".image-upload-container");
const imageUploadButton = document.querySelector(".image-upload-button");
imageUploadContainer.addEventListener('click', () => {
	imageUploadButton.click();
});
imageUploadButton.addEventListener('change', () => {
	if (imageUploadButton.files && imageUploadButton.files[0]) {
		var reader = new FileReader();
		reader.onload = function (e) {
			let imageTag = document.getElementById('Avatar');
			imageTag.src = e.target.result;
			imageUploadContainer.insertAdjacentElement('beforeend', imageTag);
		}
		reader.readAsDataURL(imageUploadButton.files[0]);
	}
});


window.rowCount2 = 1;
$("#btnAddPic").click(function (ev) {
	var template = $("#js-params-row-template-pic");
	var newRow = template.clone();				// sao chép thẻ

	newRow.removeClass('d-none').addClass('js-params-row-pic');
	newRow.removeAttr("id");

	var inputOfRow = newRow.find("input");
	inputOfRow.each(function (i, item) {
		var inputName = $(item).attr("name");
		inputName = inputName.replace("{0}", window.rowCount2);
		$(item).attr("name", inputName);
	});
	window.rowCount2++;
	// insert thẻ mới vào sau js-params-row cuối cùng
	$(".js-params-row-pic").last().after(newRow);
});