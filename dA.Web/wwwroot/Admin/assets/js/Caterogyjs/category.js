// Tạo đường dẫn tự động
const createStringUrl = (event) => {
	var title = $(event.currentTarget);
	var url = $("#Url");
	var titleValue = title.val();
	var str = convertTitleToUrl(titleValue);
	url.val(str);
}
// Kiểm tra checkbox
const enableUseUrl = () => {
	var title = $("#Name");
	var url = $("#Url");
	var checkedUseUrl = document.getElementById("checkedUseUrl");
	if (checkedUseUrl.checked) {
		url.attr('readonly', true);
		url.val(convertTitleToUrl(title.val()));
		title.attr('oninput', 'createStringUrl(event)');
	} else {
		url.attr('readonly', false);
		title.removeAttr('oninput');
	}
}
// Chuyển chuỗi tiếng việt có dấu sang không dấu
const convertTitleToUrl = (str) => {
	str = str.normalize("NFD")
		.trim()
		.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/\u0300-\u036f]/gi, '')
		.replace(/đ/g, 'd')
		.replace(/Đ/g, 'D')
		.replace(/\s+/g, "-");
	return str;
}


/* ajax lay du lieu len*/

function loaddata(_page) {
	$.ajax({
		type: 'get',
		url: '/Admin/Category/GetList?page=' + _page,
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
			console.log(page)
			loaddata(page);
		});
	});
};
function render(data) {
	return data.forEach(function (res, index) {
		var tr = $('<tr>').appendTo('tbody');
		var td = `		<td>${res.id}</td>
						<td >${res.name}</td>
						<td>${res.trademarkId}</td>
						<td data-id="${res.id}">
							<div class="btn-group text-center" role="group">
								<a href="#" class="btn btn-sm btn-outline-secondary js-update" data-id=${res.id} data-bs-toggle="modal" data-bs-target="#Category_modal">
									<i class="fas fa-edit"></i>
								</a>
								<a href="#" class="btn btn-sm btn-outline-secondary js-delete" data-id="${res.id}">
									<i class="fas fa-trash-alt"></i></a>
							</div>
						</td>`
		$(td).appendTo(tr);
	});
};
window.addEventListener('load', () => {
	loaddata();
});


// btn huy modal
$("#btnClose").on("click", function (ev) {
	$("#Id").val(null);
	$("#CategoryForm")[0].reset();
	$("#TrademarkId").append($("option").val(""));
});
// btn lưu modal
$("#btnSaveCategory").on("click", function (ev) {
	ev.preventDefault();
	var form = $("#CategoryForm");
	var data = new FormData(form[0]);
	$.ajax({
		url: "/Admin/Category/AddOrUpdate",
		data: data,
		dataType: 'json',
		type: "POST",
		processData: false,
		contentType: false,
		success: function (res) {
			if (res == true) {
				$('#Category_modal').modal('hide');
				$("#CategoryForm")[0].reset();
				Swal.fire({
					position: 'center',
					icon: 'success',
					title: 'Thao tác thành công',
					showConfirmButton: false,
					timer: 1500
				})
				loaddata();
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
})

// js delete 
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
				url: "/Admin/Category/Remove",
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
						loaddata();
					}
					else {
						Swal.fire({
							position: 'center',
							icon: 'error',
							title: 'Thao tác thất bại',
							showConfirmButton: false,
							timer: 1500
						})
						loaddata();
					}
				}

			})
		}
	});
})

const GetTrademark = () => {
	$.ajax({
		type: 'GET',
		url: "/Admin/Category/GetItemTrademark",
		success: function (res) {
			$('#TrademarkId').html('');
			render(res);
		}
	});

	function render(data) {
		var select = $('#TrademarkId');
		select.append("<option>Chọn thể loại</option>");
		return data.forEach(function (res, index) {
			var options = `
						<option value="${res.id}">${res.name}</option>
						`;
			$(options).appendTo(select);
		});
	};
}
// trademark cho luc add the loai
$("#js-GetItemTrademark").click(function () {
	GetTrademark();
})

// js-update 
$(document).on("click", ".js-update", function (ev) {
	ev.preventDefault();
	var form = $("#CategoryForm");
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	$.get("/Admin/Category/GetOne", { id: id }, function (data, textStatus, jqXHR) {
		form.find("#Id").val(data.id);
		form.find("#Name").val(data.name);
		form.find("#DisplayOrder").val(data.displayOrder);
		var options = `<option value="${data.trademarkId}">${data.trademarkId}</option>`;
		form.find("#TrademarkId").html("");
		form.find("#TrademarkId").append(options);

		$("#TrademarkId").focus(function () {
			GetTrademark();
		})
	});
})


// phan trang js 
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