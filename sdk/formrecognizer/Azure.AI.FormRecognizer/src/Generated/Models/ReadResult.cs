// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.AI.FormRecognizer;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Text extracted from a page in the input document. </summary>
    internal partial class ReadResult
    {
        /// <summary> Initializes a new instance of ReadResult. </summary>
        /// <param name="page"> The 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height and boundingBox properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        internal ReadResult(int page, float angle, float width, float height, LengthUnit unit)
        {
            Page = page;
            Angle = angle;
            Width = width;
            Height = height;
            Unit = unit;
            Lines = new ChangeTrackingList<TextLine>();
            SelectionMarks = new ChangeTrackingList<SelectionMark>();
        }

        /// <summary> Initializes a new instance of ReadResult. </summary>
        /// <param name="page"> The 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height and boundingBox properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        /// <param name="language"> The detected language on the page overall. </param>
        /// <param name="lines"> When includeTextDetails is set to true, a list of recognized text lines. The maximum number of lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order. </param>
        /// <param name="selectionMarks"> List of selection marks extracted from the page. </param>
        internal ReadResult(int page, float angle, float width, float height, LengthUnit unit, FormRecognizerLanguage? language, IReadOnlyList<TextLine> lines, IReadOnlyList<SelectionMark> selectionMarks)
        {
            Page = page;
            Angle = angle;
            Width = width;
            Height = height;
            Unit = unit;
            Language = language;
            Lines = lines;
            SelectionMarks = selectionMarks;
        }

        /// <summary> The 1-based page number in the input document. </summary>
        public int Page { get; }
        /// <summary> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </summary>
        public float Angle { get; }
        /// <summary> The width of the image/PDF in pixels/inches, respectively. </summary>
        public float Width { get; }
        /// <summary> The height of the image/PDF in pixels/inches, respectively. </summary>
        public float Height { get; }
        /// <summary> The unit used by the width, height and boundingBox properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </summary>
        public LengthUnit Unit { get; }
        /// <summary> The detected language on the page overall. </summary>
        public FormRecognizerLanguage? Language { get; }
        /// <summary> When includeTextDetails is set to true, a list of recognized text lines. The maximum number of lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order. </summary>
        public IReadOnlyList<TextLine> Lines { get; }
        /// <summary> List of selection marks extracted from the page. </summary>
        public IReadOnlyList<SelectionMark> SelectionMarks { get; }
    }
}
