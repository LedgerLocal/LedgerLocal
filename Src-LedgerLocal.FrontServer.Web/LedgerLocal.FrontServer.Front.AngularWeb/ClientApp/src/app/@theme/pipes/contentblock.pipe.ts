import { Pipe, PipeTransform } from '@angular/core';
import * as _ from 'lodash';

@Pipe({ name: 'contentBlock' })
export class ContentBlockPipe implements PipeTransform {

  transform(input: string, contentBlockList: any, defaultLabel: string = ''): string {
    input = input || '';

    if (!contentBlockList) {
      return defaultLabel;
    }

    if (!input) {
      return defaultLabel;
    }

    let findBlock = null;

    contentBlockList.forEach(function (value) {
      if (value && value.title === input) {
        findBlock = value;
      }
    });

    return findBlock === null
      ? defaultLabel
      : findBlock.content;
  }
}
