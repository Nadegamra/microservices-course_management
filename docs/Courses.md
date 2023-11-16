# Courses
## Endpoints
### Create Course
- **Short Description:** Creates a new course
- **URL:** `/courses`
- **Method:** `POST`
- **Require Authorization:** `true`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    ```javascript
    {
      "name": string
      "shortDescription": string
      "detailedDescription: string
      "lengthInDays: int
      "price": decimal
      "grantsCertificate: bool
      "certificatePrice: decimal
      "activityFormat": ActivityFormat
      "scheduleType": ScheduleType
      "difficulty": Difficulty
    }
    ```
- **Response Type:**
    ```javascript
    {
      "id": int
      "userId": int
      "name": string
      "shortDescription": string
      "detailedDescription: string
      "lengthInDays: int
      "price": decimal
      "grantsCertificate: bool
      "certificatePrice: decimal
      "activityFormat": ActivityFormat
      "scheduleType": ScheduleType
      "difficulty": Difficulty
      "requirements: CourseRequirement[]
      "gainedSkills": GainedSkill[]
      "languages": CourseLanguage[]
      "subtitles": CourseSubtitle[]
      "isHidden": bool
    }
- **Sample Request:** `POST /auth/login`
  ```json
    {
      "name": "Example course"
      "shortDescription": "Short desc"
      "detailedDescription": "Long description"
      "lengthInDays": "15"
      "price": "19.99"
      "grantsCertificate": false
      "certificatePrice": 0
      "activityFormat": "2"
      "scheduleType": "1"
      "difficulty": "0"
    }  
  ```
- **Response Codes:**
  - Course successfully created: `201 Created`
    - **Sample Response:**
      ```json
      {
          "id": 3,
          "userId": 2,
          "name": "Example course",
          "shortDescription": "Short desc",
          "detailedDescription": "Long description",
          "lengthInDays": 15,
          "price": 19.99,
          "grantsCertificate": false,
          "certificatePrice": 0,
          "activityFormat": "Mixed",
          "scheduleType": "Flexible",
          "difficulty": "Beginner",
          "requirements": null,
          "gainedSkills": null,
          "languages": null,
          "subtitles": null,
          "isHidden": true
      }
      ```
### Delete Course
### Get Course
### Get Course List
### Get Course Count
### Update Course
