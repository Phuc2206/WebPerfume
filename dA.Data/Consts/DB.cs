using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Consts
{
	public static class DB
	{

		public static class AppBlogCategory
		{
			public const string TABLE_NAME = "AppBlogCategory";
			public const short TITLE_LENGTH = 300;
			public const short SLUG_LENGTH = 300;
			public const short COVER_IMG_PATH_LENGTH = 1000;
			public const string DEFAULT_DATE = "GETDATE()";
		}

		public static class AppBlog
		{
			public const string TABLE_NAME = "AppBlog";
			public const short TITLE_LENGTH = 500;
			public const short SLUG_LENGTH = 500;
			public const short SUMMARY_LENGTH = 500;
			public const short IMAGE_LENGTH = 300;
			public const string DEFAULT_DATE = "GETDATE()";
			public const bool PUBLIC_NEWS = true;
			public const string DEFAULT_VALUE = null;
			public const short COUNT = 0;
		}

	}
}
