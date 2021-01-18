﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UsingHangfireInASPNETCore_Demo.Data;

namespace UsingHangfireInASPNETCore_Demo.Services
{
    public class ImageService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly BlobStorageService blobStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public ImageService(
            ApplicationDbContext dbContext,
            BlobStorageService blobStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            this.dbContext = dbContext;
            this.blobStorage = blobStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task UploadAndProcessImageAsync(string fileName, MemoryStream stream)
        {
            var authState = await this.authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                
            }

            var aspNetUserID = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            string uniqueFileName = $"{Guid.NewGuid()}{fileName}";

            // calculate the md5 hash and ensure it was already uploaded
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string md5ByteString = System.Text.Encoding.Default.GetString(md5.ComputeHash(stream));

            if(this.dbContext.OriginalImages.Any(x => x.MD5Hash == md5ByteString))
            {
                // do something
            }

            // if it wasn't, upload the original and delegate the 
            var originalImageRecord = new OriginalImage
            {
                DisplayName = fileName,
                FileName = uniqueFileName,
                AspNetUserID = aspNetUserID,
                MD5Hash = md5ByteString,
                ContainerOrDirectory = "OriginalImages",
                CreatedAt = DateTime.UtcNow
            };

            this.dbContext.OriginalImages.Add(originalImageRecord);
            await this.dbContext.SaveChangesAsync();

            stream.Position = 0;

            await this.blobStorage.UploadItemAsync("OriginalImages", uniqueFileName, stream);

        }


    }
}
