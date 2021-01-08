export interface ITagDto {
   content: string;
   hexColor: string;
}

export class TagDto implements ITagDto {
   content: string;
   hexColor: string;

   constructor(dto: ITagDto) {
      this.content = dto.content;
      this.hexColor = dto.hexColor;
   }

}