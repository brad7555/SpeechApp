CREATE TABLE [dbo].[AudioFiles](  
    [ID] [int] IDENTITY(1,1) NOT NULL,  
    [Name] [nvarchar](50) NULL,  
    [FileSize] [int] NULL,  
    [FilePath] [nvarchar](100) NULL,  
 CONSTRAINT [PK_AudioFiles] PRIMARY KEY CLUSTERED   
(  
    [ID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
  
CREATE procedure [dbo].[spGetAllAudioFile]  
as  
begin  
select ID,Name,FileSize,FilePath from AudioFiles  
end  
